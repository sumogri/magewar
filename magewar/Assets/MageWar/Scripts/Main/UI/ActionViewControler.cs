using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ActionViewControler : MonoBehaviour {
    private Button[] buttons;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
        buttons = gameObject.GetComponentsInChildren<Button>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Activate()
    {
        gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
    }
}
