using UnityEngine;
using System.Collections;

/// <summary>
/// マップチップ1マスあたりの管理
/// </summary>
public class MapChipControler : MonoBehaviour {

    #region フィールド
    private GameObject onUnit = null;  //チップ上のユニット
    private MapChipManager.IVector2 celpos; //セル上の場所
    #endregion

    #region アクセサ
    #endregion

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    #region colliderのイベントハンドラ
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Unit")
        {
            onUnit = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Unit")
        {
            onUnit = null;
        }
    }
    #endregion
}
