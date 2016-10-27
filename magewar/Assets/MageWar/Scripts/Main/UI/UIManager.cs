using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class UIManager : MonoBehaviour {
    private ActionViewControler actionview; //行動選択ビュー
    private MapChipManager mapchipManager;

    public ActionViewControler ActView
    {
        get { return actionview; }
    }
    public MapChipManager MapChipMan
    {
        get { return mapchipManager; }
    }

    // Use this for initialization
    void Start() {
        actionview = gameObject.GetComponentInChildren<ActionViewControler>();
        mapchipManager = GameObject.Find("MapChips").GetComponent<MapChipManager>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void ActivateAct()
    {
        actionview.Activate();
        mapchipManager.SetIntaractive(false);
    }
    public void HideAct()
    {
        actionview.Hide();
        mapchipManager.SetIntaractive(true);
        EventSystem.current.SetSelectedGameObject(mapchipManager.ChoseChip.gameObject);
    }

}
