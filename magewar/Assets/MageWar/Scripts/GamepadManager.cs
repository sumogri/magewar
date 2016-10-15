using UnityEngine;
using System.Collections;

public class GamepadManager : SingletonMonoBehaviour<GamepadManager> {

    public enum KeyMean {ZoomIn,ZoomOut,UD,LR};
    static private string[] keyName = {"RB","LB","Horizontal","Vertical"};

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    static public bool GetButtonDown(KeyMean val)
    {
        return Input.GetButtonDown(keyName[(int)val]);
    }
}
