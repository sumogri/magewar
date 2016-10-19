using UnityEngine;
using System.Collections;

public class MapChipManager : MonoBehaviour {
    [SerializeField]
    private GameObject planeChip;   //平地マップチップ
    

	// Use this for initialization
	void Start () {
        makeChips();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void makeChips()
    {
        GameObject newChip = GameObject.Instantiate(planeChip);
        newChip.transform.SetParent(transform,false);
    }
}
