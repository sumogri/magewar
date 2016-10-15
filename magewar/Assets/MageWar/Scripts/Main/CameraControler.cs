using UnityEngine;
using System.Collections;

public class CameraControler : MonoBehaviour
{

    private GameObject target = null;
    private Vector3[] offsets;
    [SerializeField]
    private Transform[] points;
    private int pointsState = 0;
    

    void Start()
    {
        offsets = new Vector3[points.Length];
        target = GameObject.FindGameObjectWithTag("Player");
        //offsets = transform.position - target.transform.position;
        for(int i = 0; i < points.Length; i++)
        {
            offsets[i] = points[i].position - target.transform.position;
        }
    }

    void LateUpdate()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = target.transform.position.x + offsets[pointsState].x;
        newPosition.y = target.transform.position.y + offsets[pointsState].y;
        newPosition.z = target.transform.position.z + offsets[pointsState].z;
        transform.position = Vector3.Lerp(transform.position, newPosition, 5.0f * Time.deltaTime);

        bool button = Input.GetButtonDown("ZoomIn");
        Debug.Log("zoomin " + button);
    }
}