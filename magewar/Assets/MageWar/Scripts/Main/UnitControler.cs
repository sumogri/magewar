using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitControler : MonoBehaviour {
    #region ステータス
    protected int movepow = 5; //一ターンあたり移動可能なマス数
    protected string unitName = "Queryちゃん"; //ユニットの名前
    protected int hp = 12;  //体力
    protected string job = "みならい魔女"; //職業名
    #endregion
    
    protected LinkedList<Vector3> moveToAngles;   //移動方向群
    protected float moveTime = 0.5f; //1マスあたりの移動に使う時間
    private bool isMoveing = false; //移動中か
    private float moveStartTime; //移動先セットされた時間
    private Vector3 startPos;
    private Vector3 endPos;
    private NavMeshAgent agent;

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
        agent = gameObject.GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isMoveing)
        {
            float difftime = Time.timeSinceLevelLoad - moveStartTime;
            if(difftime > moveTime)
            {
                transform.position = endPos;
                if(moveToAngles.Count > 0)
                {
                    startPos = endPos;
                    endPos = startPos + moveToAngles.First.Value * 2f;
                    moveToAngles.RemoveFirst();
                    moveStartTime = Time.timeSinceLevelLoad;
                }
                else
                {
                    isMoveing = false;
                }
            }
            else
                transform.position = Vector3.Lerp(startPos,endPos,difftime/moveTime);
        }
	}
    
    public void SetMove(Vector3 to)
    {
        agent.SetDestination(to);
    }
}
