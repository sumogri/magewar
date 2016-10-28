using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// マップチップのカーソルとしてのふるまい
/// </summary>
public class CursorControler : MonoBehaviour, ISelectHandler, IDeselectHandler,ISubmitHandler,ICancelHandler
{
    private CameraControler mainCameraControler; //注目させるためのカメラ

    private UnitStateViewControler unitState;       //ユニット状態を表示するUIのコントローラ
    private MoveAbleUI moveableUI;              //移動範囲UI
    
    private MapChipControler controler;

    // Use this for initialization
    void Start () {
        mainCameraControler = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControler>();
        unitState = GameObject.Find("UnitStateView").GetComponent<UnitStateViewControler>();
        controler = gameObject.GetComponent<MapChipControler>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

 
    #region eventHandlers
    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        mainCameraControler.Target = gameObject;
        if(controler.OnUnit != null)
            unitState.SetState(controler.OnUnit);
    }

    void IDeselectHandler.OnDeselect(BaseEventData eventData)
    {
        unitState.Hide();
    }

    void ISubmitHandler.OnSubmit(BaseEventData eventData)
    {
        //ユニットの乗ってない移動不可マスでは,何も起きない
        if(controler.OnUnit == null && !controler.IsMoveable)
            return;
        
        //移動可能マスであり,移動選択ユニットが味方だった場合
        if (controler.IsMoveable &&
            controler.Manager.ChoseUnit.Region == UnitManager.UnitRegion.mine)
        {
            //移動先を決定,移動
            controler.Manager.ChoseUnit.SetMove(gameObject.transform.position+Vector3.forward+Vector3.right);
            mainCameraControler.Target = controler.Manager.ChoseUnit.gameObject;
            controler.Manager.MoveableViewEnable(false);
            controler.SetIMoveToChip();
            EventSystem.current.SetSelectedGameObject(null);
        }
        //乗ってるユニットが行動済みでない場合
        else if (controler.OnUnit != null && !controler.OnUnit.IsMoved)
        {
            //現在の移動選択状態を解除
            controler.Manager.MoveableOff();

            //移動先を表示する
            controler.Manager.SerchMoveable(controler.OnUnit,controler.CelPosition);
            controler.Manager.MoveableViewEnable(true);
            controler.SetIChoseUnit();
            controler.SetIChoseChip();
        }

    }

    void ICancelHandler.OnCancel(BaseEventData eventData)
    {
        controler.Manager.MoveableOff();
    }
    #endregion
}
