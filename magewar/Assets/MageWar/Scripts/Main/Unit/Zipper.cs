using UnityEngine;
using System.Collections;

public class Zipper : UnitControler {

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        unitName = "ジッパーくん";
        job = "マミー";
        movepow = 5;
        hp = 14;
        region = UnitManager.UnitRegion.enemy;
    }

    // Update is called once per frame
    void Update () {
	}
}
