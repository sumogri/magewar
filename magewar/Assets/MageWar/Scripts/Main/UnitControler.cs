using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class UnitControler : MonoBehaviour {
    #region ステータス
    protected int movepow;       //一ターンあたり移動可能なマス数
    protected string unitName;   //ユニットの名前
    protected int hp;            //体力
    protected string job;        //職業名
    protected UnitManager.UnitRegion region; //所属
    #endregion
    
    protected NavMeshAgent agent;
    protected NavMeshObstacle obstacle;
    private Vector3 endPosition;
    private Collider mycollider;

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
    public UnitManager.UnitRegion Region
    {
        get { return region; }
    }
    #endregion

    // Use this for initialization
    public virtual void Start () {
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.enabled = false;
        obstacle = gameObject.GetComponent<NavMeshObstacle>();
        obstacle.enabled = true;
        mycollider = gameObject.GetComponent<Collider>();
    }

	// Update is called once per frame
	public virtual void Update() {

        //agentの移動完了を検知
        if(agent.enabled && !agent.pathPending && agent.remainingDistance < 0.001)
        {
            agent.enabled = false;
            obstacle.enabled = true;
        }
    }

    public void SetMove(Vector3 to)
    {
        endPosition = to;
        if (region != UnitManager.UnitRegion.mine)
            return;
        obstacle.enabled = false;
        agent.enabled = true;
        agent.SetDestination(to);
    }   
}
