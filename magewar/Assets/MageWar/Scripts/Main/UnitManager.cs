using UnityEngine;
using System.Collections;

public class UnitManager : MonoBehaviour {
    private static string[] unitRegionStr = { "味方", "敵" };
    private UIManager uiManager;

    public UIManager UiManager
    {
        get { return uiManager; }
    }

	// Use this for initialization
	void Start () {
        uiManager = GameObject.Find("UIs").GetComponent<UIManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public enum UnitRegion
    {
        mine,enemy,
    }
    public static string UnitRegionStr(UnitRegion reg)
    {
        return unitRegionStr[(int)reg];
    }
}
