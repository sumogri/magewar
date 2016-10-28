using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// マップチップ1マスあたりの管理
/// </summary>
public class MapChipControler : MonoBehaviour, ISelectHandler
{

    #region フィールド
    private List<UnitControler> onUnits = new List<UnitControler>(); //チップ上のユニット
    private MapChipManager.IVector2 celpos; //セル上の場所
    private Collider mycollider;
    private LandformState landform;
    private bool isMoveable = false;
    private int remainingMove = 0;  //残り移動量
    private MapChipManager manager;
    private Image moveableImage;
    private Image atkableImage;
    private Selectable mySelectable;
    #endregion

    #region アクセサ
    public UnitControler OnUnit
    {
        get { return (onUnits.Count == 0) ? null : onUnits[0]; }
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
        set { isMoveable = value;}
    }
    public Image MovalView
    {
        get { return moveableImage; }
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
    public Selectable MySelectable
    {
        get { return mySelectable; }
    }
    #endregion

    // Use this for initialization
    void Start () {
        mycollider = gameObject.GetComponent<Collider>();
        landform = gameObject.GetComponent<LandformState>();
        manager = transform.parent.gameObject.GetComponent<MapChipManager>();
        moveableImage = gameObject.transform.FindChild("moveable").GetComponent<Image>();
        moveableImage.enabled = false;
        atkableImage = gameObject.transform.FindChild("atkable").GetComponent<Image>();
        atkableImage.enabled = false;
        mySelectable = gameObject.GetComponent<Selectable>();
    }

    // Update is called once per frame
    void Update () {
	}

    public void SetIChoseUnit()
    {
        manager.ChoseUnit = onUnits[0];
    }
    public void SetIChoseChip()
    {
        manager.ChoseChip = this; 
    }
    public void SetIMoveToChip()
    {
        manager.MoveToChip = this;
    }

    #region colliderのイベントハンドラ
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Unit")
        {
            UnitControler onUnit = other.GetComponent<UnitControler>();
            onUnits.Add(onUnit);
            //Debug.Log("Enter" + celpos.X.ToString() + ":" + celpos.Y.ToString());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Unit")
        {
            UnitControler unit = other.GetComponent<UnitControler>();
            onUnits.Remove(unit);
            //Debug.Log("Exit" + celpos.X.ToString() + ":" + celpos.Y.ToString());
        }
    }

    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        Debug.Log(celpos.X.ToString() + celpos.Y.ToString());
    }

    #endregion
}
