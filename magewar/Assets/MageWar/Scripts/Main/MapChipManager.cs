using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class MapChipManager : MonoBehaviour
{
    [SerializeField]
    private CameraControler mainCameraControler; //注目させるためのカメラ

    private IVector2 mapCelSize = new IVector2(10,10);  //マップチップの最大配置数

    private List<GameObject> chips = new List<GameObject>();

	// Use this for initialization
	void Start () {
        //子オブジェクトを取得しておく
        foreach (Transform child in transform)        
            chips.Add(child.gameObject);
        
        EventSystem.current.firstSelectedGameObject = chips[0];
	}
	
	// Update is called once per frame
	void Update () {
	}

    //自動化用メソッド
    /*
    private GameObject makeChips(GameObject chip)
    {
        GameObject newChip = GameObject.Instantiate(chip);
        newChip.transform.SetParent(transform,false);
        return newChip;
    }
    */

    /// <summary>
    /// マップチップ座標管理用 pair int
    /// </summary>
    private class IVector2
    {
        public int X;
        public int Y;

        public IVector2(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
