using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ActionViewControler : MonoBehaviour {
    private Button[] buttons;
    private UIManager manager;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
        buttons = gameObject.GetComponentsInChildren<Button>();
        manager = gameObject.transform.parent.GetComponent<UIManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("ActViewCancel");
            manager.MapChipMan.MoveCancel();
            this.Hide();
        }
	}

    public void Activate()
    {
        gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}