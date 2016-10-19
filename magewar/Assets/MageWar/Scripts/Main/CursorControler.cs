using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CursorControler : MonoBehaviour {
    private float speed = 2f; //カーソルの一回当たりの移動量
    private float cursorMoveableTime = 0.1f; //アナログスティックの再入力受付時間
    private float asixInputingTime; //アナログスティックの連続入力時間

    private UnitStateControler unitState;   //ユニット状態を表示するUIのコントローラ
    private MoveAbleUI moveableUI;  //移動範囲UI

    [SerializeField]
    private Material cursorMat;   //カーソルのマテリアル(デバッグ用)
    private UnitControler enterUnit;    //最後にカーソルに触れたユニット
    private UnitControler chosingUnit;    //選択中のユニット
    private bool isChosing = false; //ユニットを移動選択中か
    private LinkedList<Vector3> movedPosList;

    // Use this for initialization
    void Start () {
        unitState = GameObject.Find("UnitState").GetComponent<UnitStateControler>();
        moveableUI = GameObject.Find("MoveAbleArea").GetComponent<MoveAbleUI>();
        movedPosList = new LinkedList<Vector3>();
    }
	
	// Update is called once per frame
	void Update () {
        float hor = 0;
        float var = 0;

        if (getAsix(ref hor, ref var))
        {
            this.moveUpdate(hor, var);
        }

        if (Input.GetButtonDown("Cancel") && isChosing)
        {
            cursorMat.color = Color.red;
            moveableUI.Hide();
            isChosing = false;
            chosingUnit.SetMove(movedPosList);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Unit")
        {
            enterUnit = other.GetComponent<UnitControler>();
            unitState.SetState(enterUnit);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Unit")
        {
            unitState.Hide();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Submit") && !isChosing)
        {
            cursorMat.color = Color.blue;
            chosingUnit = enterUnit;
            moveableUI.Activeate(gameObject.transform.position, chosingUnit.MovePower);
            isChosing = true;
        }
    }

    /// <summary>
    /// 一定時間毎にゲームパッドから移動方向を取得する
    /// </summary>
    /// <param name="hor">水平方向のasix値格納先</param>
    /// <param name="var">垂直方向のasix値格納先</param>
    /// <returns>Asixの取得に成功したか</returns>
    private bool getAsix(ref float hor,ref float var)
    {
        hor = Input.GetAxis("Horizontal");
        var = Input.GetAxis("Vertical");

        #region 一定時間おきに入力をとる
        if (hor != 0f || var != 0f)
        {
            asixInputingTime += Time.deltaTime;
            if (asixInputingTime >= cursorMoveableTime)
            {
                asixInputingTime = 0;
                return true;
            }
        }
        else
        {
            asixInputingTime = 0;
            return false;
        }
        #endregion

        return false;
    }

    /// <summary>
    /// カーソルを移動させる
    /// </summary>
    /// <param name="hor">垂直方向のAsix値</param>
    /// <param name="var">垂直方向のAsix値</param>
    private void moveUpdate(float hor,float var)
    {
        Vector3 moveVec = Vector3.zero;
        
        if (hor > 0.5)
        {
            moveVec = Vector3.right;
        }
        else if (hor < -0.5)
        {
            moveVec = Vector3.left;
        }
        if (var > 0.5)
        {
            moveVec = Vector3.forward;
        }
        else if (var < -0.5)
        {
            moveVec = Vector3.back;
        }
        
        #region カーソルの移動をユニットに伝えるための処理
        if (isChosing)
        {
            //スレッドセーフにする
            if (movedPosList.Count != 0 && (moveVec * -1) == movedPosList.Last.Value)
            {
                movedPosList.RemoveLast();
            }
            else
            {
                movedPosList.AddLast(moveVec);
            }
        }
        #endregion

        gameObject.transform.position += moveVec * speed;         //移動

    }
}
