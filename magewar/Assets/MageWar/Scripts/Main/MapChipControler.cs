using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

/// <summary>
/// マップチップ1マスあたりの管理
/// </summary>
public class MapChipControler : MonoBehaviour, ISelectHandler
{

    #region フィールド
    private UnitControler onUnit = null;  //チップ上のユニット
    private MapChipManager.IVector2 celpos; //セル上の場所
    private LandformState landform;
    private bool isMoveable = false;
    private int remainingMove = 0;  //残り移動量
    private MapChipManager manager;
    private Image moveableImage;
    private Image atkableImage;
    #endregion

    #region アクセサ
    public UnitControler OnUnit
    {
        get { return onUnit; }
    }
    public MapChipManager.IVector2 CelPosition
    {
        get { return celpos; }
        set { celpos = value; }
    }
    public LandformState Landform
    {
        get { return landform; }
    }
    public bool IsMoveable
    {
        get { return isMoveable; }
        set { isMoveable = value;
            moveableImage.enabled = value; ;
        }
    }
    public int RemainingMove
    {
        get { return remainingMove; }
        set { remainingMove = value; }
    }
    public MapChipManager Manager
    {
        get { return manager; }
    }
    #endregion

    // Use this for initialization
    void Start () {
        landform = gameObject.GetComponent<LandformState>();
        manager = transform.parent.gameObject.GetComponent<MapChipManager>();
        moveableImage = gameObject.transform.FindChild("moveable").GetComponent<Image>();
        moveableImage.enabled = false;
        atkableImage = gameObject.transform.FindChild("atkable").GetComponent<Image>();
        atkableImage.enabled = false;
    }

    // Update is called once per frame
    void Update () {
	}

    public void ChoseUnit()
    {
        manager.ChoseUnit = onUnit.GetComponent<UnitControler>();
    }

    #region colliderのイベントハンドラ
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Unit")
        {
            onUnit = other.GetComponent<UnitControler>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Unit")
        {
            onUnit = null;
        }
    }

    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        Debug.Log(celpos.X.ToString() + celpos.Y.ToString());
    }

    #endregion
}
