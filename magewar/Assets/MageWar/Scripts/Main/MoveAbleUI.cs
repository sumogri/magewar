using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveAbleUI : MonoBehaviour {
    private Image able;

	// Use this for initialization
	void Start () {
        able = gameObject.GetComponentInChildren < Image >();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Activeate(Vector3 pos,int movepow)
    {
        gameObject.transform.position = new Vector3(pos.x + 1, gameObject.transform.position.y, pos.z + 1);
        Queue posque = new Queue();
        
        for(int i = 0; i < movepow; i++)
        {
            for(int j = 0; j < movepow; j++)
            {
                
            }
        }
    }
    
}
