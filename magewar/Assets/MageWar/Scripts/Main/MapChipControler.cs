using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class MapChipControler : MonoBehaviour, ISelectHandler
{
    [SerializeField]
    private CameraControler mainCameraControler;    

    [SerializeField]
    private string chipkind;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnSelect(BaseEventData eventData)
    {
        mainCameraControler.Target = gameObject;
    }
}
