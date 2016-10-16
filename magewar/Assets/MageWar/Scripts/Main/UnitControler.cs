using UnityEngine;
using System.Collections;

public class UnitControler : MonoBehaviour {
    #region ステータス
    protected int movepow = 5; //一ターンあたり移動可能なマス数
    protected string unitName = "Queryちゃん"; //ユニットの名前
    protected int hp = 12;  //体力
    protected string job = "みならい魔女"; //職業名
    #endregion

    #region プロパティ
    public string UnitName
    {
        get { return unitName; }
    }
    public int HP
    {
        get { return hp; }
    }
    public string Job
    {
        get { return job; }
    }
    public int MovePower
    {
        get { return movepow; }
    }
    #endregion

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        
	}
    
}
