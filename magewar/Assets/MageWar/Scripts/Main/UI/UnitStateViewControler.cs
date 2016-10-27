using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UnitStateViewControler : MonoBehaviour {
    private Text[] texts;
    private Image[] images;
    private Canvas canvas;

	// Use this for initialization
	void Start () {
        images = gameObject.GetComponentsInChildren<Image>();
        texts = gameObject.GetComponentsInChildren<Text>();
        canvas = gameObject.GetComponent<Canvas>();
        this.Hide();
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void Hide()
    {
        canvas.enabled = false;
    }

    public void SetState(UnitControler unit)
    {
        canvas.enabled = true;
        foreach(Image image in images)
            image.enabled = false;

        images[(int)unit.Region].enabled = true; 
        texts[0].text = unit.UnitName;
        texts[1].text = unit.HP.ToString();
        texts[2].text = unit.Job;
    }
}
