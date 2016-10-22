using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// マップチップのカーソルとしてのふるまい
/// </summary>
public class CursorControler : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private CameraControler mainCameraControler; //注目させるためのカメラ

    private Collider myCollider;
    private UnitStateControler unitState;       //ユニット状態を表示するUIのコントローラ
    private MoveAbleUI moveableUI;              //移動範囲UI

    private UnitControler chosingUnit;          //選択候補のユニット
    private bool isChoseable = false;           //ユニットを選択可能か
    

    // Use this for initialization
    void Start () {
        myCollider = gameObject.GetComponent<Collider>();
        mainCameraControler = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControler>();
        unitState = GameObject.Find("UnitState").GetComponent<UnitStateControler>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    #region by Collider Controle
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Unit")
        {
            chosingUnit = other.GetComponent<UnitControler>();
            unitState.SetState(chosingUnit);
            isChoseable = true;
        }
    }
    
    #endregion

    #region by UI Controle
    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        mainCameraControler.Target = gameObject;
    }

    void IDeselectHandler.OnDeselect(BaseEventData eventData)
    {
        unitState.Hide();
    }

    public void OnClickSubmit()
    {
        if (isChoseable)
        {
            Debug.Log("Chose");
        }
    }
    #endregion
}
