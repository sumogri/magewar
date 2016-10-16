using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CursorControler : MonoBehaviour {
    private float speed = 2f; //カーソルの一回当たりの移動量
    private float cursorMoveableTime = 0.1f; //アナログスティックの再入力受付時間
    private float asixInputingTime; //アナログスティックの連続入力時間

    private UnitStateControler unitState;   //ユニット状態を表示するUIのコントローラ
    

    // Use this for initialization
    void Start () {
        unitState = GameObject.Find("UnitState").GetComponent<UnitStateControler>();
	}
	
	// Update is called once per frame
	void Update () {
        float hor = 0;
        float var = 0;

        if (getAsix(ref hor, ref var))
        {
            this.moveUpdate(hor, var);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Unit")
        {
            unitState.SetState(other.GetComponent<UnitControler>());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Unit")
        {
            unitState.Hide();
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
            return true;
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
        if (hor > 0.5)
        {
            gameObject.transform.position += Vector3.right * speed;
        }
        else if (hor < -0.5)
        {
            gameObject.transform.position += Vector3.left * speed;
        }
        if (var > 0.5)
        {
            gameObject.transform.position += Vector3.forward * speed;
        }
        else if (var < -0.5)
        {
            gameObject.transform.position += Vector3.back * speed;
        }
    }
}
