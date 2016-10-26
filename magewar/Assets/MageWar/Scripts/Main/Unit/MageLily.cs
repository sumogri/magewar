using UnityEngine;
using System.Collections;

public class MageLily : UnitControler {

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        unitName = "クエリちゃん";
        job = "見習い魔女";
        movepow = 5;
        hp = 14;
        region = UnitManager.UnitRegion.mine;
    }

    // Update is called once per frame
    public override void Update () {
        base.Update();
	}
}
