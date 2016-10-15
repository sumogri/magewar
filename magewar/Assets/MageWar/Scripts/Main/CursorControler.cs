using UnityEngine;
using System.Collections;

public class CursorControler : MonoBehaviour {
    private float speed = 2f;
    private float cursorMoveableTime = 0.1f;
    private float asixInputingTime;
    private bool inputable = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float hor = Input.GetAxis("Horizontal");
        float var = Input.GetAxis("Vertical");
        //Debug.Log("hor" + hor + "var" + var);

        #region 一定時間おきに入力をとる
        if (hor != 0f || var != 0f)
        {
            asixInputingTime += Time.deltaTime;
            if(asixInputingTime >= cursorMoveableTime)
            {
                inputable = true;
                asixInputingTime = 0;
            }
        }
        else
        {
            asixInputingTime = 0;
            inputable = true;
        }
        #endregion

        if (inputable)
        {
            inputable = false;
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
}
