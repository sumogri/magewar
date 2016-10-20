using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

/// <summary>
/// 地形情報
/// </summary>
public class MapChipState : MonoBehaviour, ISelectHandler
{
    #region フィールド
    [SerializeField]
    protected MapChipKind chipKind = MapChipKind.plane;
    protected float[] hideRates = { 10, 30 };
    protected float[] diffences = { 2, 1 };
    private MapChipViewControler view;
    #endregion

    #region アクセサ
    public MapChipKind ChipKind
    {
        get { return chipKind; }
    }
    public float HideRate {
        get { return hideRates[(int)chipKind]; }
    }
    public float Diffence
    {
        get { return diffences[(int)chipKind]; }
    }
    public string ChipKindStr
    {
        get { return mapChipKindStr[(int)chipKind]; }
    }
    #endregion

    #region マップチップの種類
    public enum MapChipKind
    {
        plane, tussock,
    }
    private string[] mapChipKindStr = { "平原", "草叢" };
    #endregion

    void Start()
    {
        view = GameObject.Find("MapChipView").GetComponent<MapChipViewControler>();
    }

    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        view.SetState(this);
    }
}

