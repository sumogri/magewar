using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class WaitButton : MonoBehaviour,ISubmitHandler {
    private MapChipManager mapManager;
    private ActionViewControler controler;

    // Use this for initialization
    void Start () {
        mapManager = GameObject.Find("MapChips").GetComponent<MapChipManager>();
        controler = GameObject.Find("ActionView").GetComponent<ActionViewControler>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void ISubmitHandler.OnSubmit(BaseEventData eventData)
    {
        mapManager.ChoseUnit.Wait();
        EventSystem.current.SetSelectedGameObject(mapManager.MoveToChip.gameObject);
        mapManager.MoveableOff();
        mapManager.SetIntaractive(true);
        controler.Hide();
    }
}
