using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class WaitButton : MonoBehaviour,ISubmitHandler {
    private MapChipManager mapManager;

    // Use this for initialization
    void Start () {
        mapManager = GameObject.Find("MapChips").GetComponent<MapChipManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void ISubmitHandler.OnSubmit(BaseEventData eventData)
    {
        mapManager.ChoseUnit.Wait();
        mapManager.MoveableOff();
    }
}
