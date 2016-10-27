﻿using UnityEngine;
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
        if (controler.IsMoveable)
        {
            controler.Manager.ChoseUnit.SetMove(gameObject.transform.position+Vector3.forward+Vector3.right);
            mainCameraControler.Target = controler.Manager.ChoseUnit.gameObject;
            controler.Manager.MoveableOff();
            EventSystem.current.SetSelectedGameObject(null);
        }
        else if (controler.OnUnit != null)
        {
            controler.Manager.SerchMoveable(controler.OnUnit,controler.CelPosition);
            controler.ChoseUnit();
        }
        
    }

    void ICancelHandler.OnCancel(BaseEventData eventData)
    {
        controler.Manager.MoveableOff();
    }
    #endregion
}
