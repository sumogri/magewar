using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

/// <summary>
/// 地形情報
/// </summary>
public class LandformState : MonoBehaviour, ISelectHandler
{
    #region フィールド
    [SerializeField]
    private MapChipKind chipKind = MapChipKind.plane;
    private float[] hideRates = { 10, 30 ,0};
    private float[] diffences = { 2, 1 ,0};
    private int[] moveCosts = { 1, 2 ,100};   //基本コスト
    private LandformViewControler view;
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
    public int MoveCost
    {
        get { return moveCosts[(int)chipKind]; }
    }
    #endregion

    #region マップチップの種類
    public enum MapChipKind
    {
        plane, tussock,wall
    }
    private string[] mapChipKindStr = { "平原", "草叢","壁" };
    #endregion

    void Start()
    {
        view = GameObject.Find("LandformView").GetComponent<LandformViewControler>();
    }

    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        view.SetState(this);
    }
}

