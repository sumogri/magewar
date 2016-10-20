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
    protected MapChipKind chipKind = MapChipKind.plane;
    protected float hideRate = 10;
    protected float diffence = 2;
    private MapChipViewControler view;
    #endregion

    #region アクセサ
    public MapChipKind ChipKind
    {
        get { return chipKind; }
    }
    public float HideRate {
        get { return hideRate; }
    }
    public float Diffence
    {
        get { return diffence; }
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

