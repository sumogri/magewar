using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LandformViewControler : MonoBehaviour {
    private Text[] texts;
    

	// Use this for initialization
	void Start () {
       texts = gameObject.GetComponentsInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetState(LandformState state)
    {
        texts[0].text = state.ChipKindStr;
        texts[1].text = state.HideRate.ToString();
        texts[2].text = state.Diffence.ToString();
    }
}
