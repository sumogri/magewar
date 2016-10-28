using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ActionViewControler : MonoBehaviour {
    private Button[] buttons;
    private UIManager manager;
    private Canvas canvas;

	// Use this for initialization
	void Start () {
        buttons = gameObject.GetComponentsInChildren<Button>();
        manager = gameObject.transform.parent.GetComponent<UIManager>();
        canvas = gameObject.GetComponent<Canvas>();
        this.Hide();
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
        foreach (Button button in buttons)
            button.interactable = true;
        canvas.enabled = true;
        this.enabled = true;
        EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
    }
    public void Hide()
    {
        foreach(Button button in buttons)
            button.interactable = false;
        this.enabled = false;
        canvas.enabled = false;
    }
}