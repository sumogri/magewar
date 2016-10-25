using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System;

public class MapChipManager : MonoBehaviour
{
    [SerializeField]
    private CameraControler mainCameraControler; //注目させるためのカメラ

    private IVector2 mapCelSize = new IVector2(10,10);  //マップチップの最大配置数

    private List<MapChipControler> chips = new List<MapChipControler>();
    private List<MapChipControler> moveable = new List<MapChipControler>();
    private UnitControler choseUnit;

    //カーソルが選択中のユニット
    public UnitControler ChoseUnit
    {
        get { return choseUnit; }
        set { choseUnit = value; }
    }

    // Use this for initialization
    void Start () {

        //子オブジェクトを取得しておく
        int x=0, y=0;
        foreach (Transform child in transform)
        {
            MapChipControler addchip = child.gameObject.GetComponent<MapChipControler>();
            chips.Add(addchip);
            addchip.CelPosition = new IVector2(x, y);
            if(++x >= mapCelSize.X)
            {
                x = 0; y++;
            }
        }        
        EventSystem.current.firstSelectedGameObject = chips[0].gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void MoveableOff()
    {
        foreach (MapChipControler chip in moveable)
        {
            chip.IsMoveable = false;
        }
        moveable.Clear();
    }


    #region 自動化用メソッド
    /*
    private GameObject makeChips(GameObject chip)
    {
        GameObject newChip = GameObject.Instantiate(chip);
        newChip.transform.SetParent(transform,false);
        return newChip;
    }*/
    #endregion

    public void SerchMoveable(UnitControler unit,IVector2 pos)
    {
        Queue<IVector2> posque = new Queue<IVector2>();
        posque.Enqueue(pos);
        chips[Toint(pos)].IsMoveable = true;
        chips[Toint(pos)].RemainingMove = unit.MovePower;

        while (posque.Count > 0)
        {
            IVector2 nowpos = posque.Dequeue();
            int index = Toint(nowpos);
            int movePow = chips[index].RemainingMove;

            //移動可能チップリストの更新
            moveable.Add(chips[index]);

            for (int i = 0; i < 4; i++)
            {
                IVector2 newpos = nowpos.Step(i);
                //枠内であるか
                if (newpos.X < mapCelSize.X && newpos.X >= 0 && newpos.Y < mapCelSize.Y && newpos.Y >= 0)
                {
                    index = Toint(newpos);
                    int remain = movePow - chips[index].Landform.MoveCost;
                    //行ったことなくて、いける or 行ったことあって、もっとパワー残していける
                    if (!chips[index].IsMoveable &&  remain >= 0 ||
                        chips[index].IsMoveable && chips[index].RemainingMove < remain)
                    {
                        chips[index].IsMoveable = true;
                        chips[index].RemainingMove = remain;
                        posque.Enqueue(newpos);
                    }
                }
            }
            
        }
    }

    private int Toint(IVector2 vec)
    {
        return vec.X + vec.Y * mapCelSize.X;
    }
   

    /// <summary>
    /// マップチップ座標管理用 pair int
    /// </summary>
    public class IVector2
    {
        public int X;
        public int Y;

        public IVector2(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }
        //各軸方向に1ずつ数値を勧めたIVectorを返す
        public IVector2 Step(int kind)
        {
            switch (kind)
            {
                case 0:
                    return new IVector2(X + 1, Y);
                case 1:
                    return new IVector2(X - 1, Y);
                case 2:
                    return new IVector2(X, Y + 1);
                case 3:
                    return new IVector2(X, Y - 1);
            }
            return new IVector2(X, Y);
        }
    }
}
