using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CameraControler : MonoBehaviour
{

    private GameObject target = null;
    private Vector3[] offsets;
    [SerializeField]
    private Transform[] points;
    private int pointsState = 0;
    
    public GameObject Target
    {
        set { target = value; }
    }

    void Start()
    {
        offsets = new Vector3[points.Length];
        target = EventSystem.current.firstSelectedGameObject;
        for(int i = 0; i < points.Length; i++)
        {
            offsets[i] = points[i].position - target.transform.position;
        }
    }

    void LateUpdate()
    {
        #region 追従処理
        Vector3 newPosition = transform.position;
        newPosition.x = target.transform.position.x + offsets[pointsState].x;
        newPosition.y = target.transform.position.y + offsets[pointsState].y;
        newPosition.z = target.transform.position.z + offsets[pointsState].z;
        transform.position = Vector3.Lerp(transform.position, newPosition, 5.0f * Time.deltaTime);
        #endregion

        #region ズーム処理
        if (Input.GetButtonDown("Zoomout"))
        {
            pointsState++;
            if (pointsState >= points.Length)
                pointsState = 0;
        }
        if (Input.GetButtonDown("Zoomin"))
        {
            pointsState--;
            if (pointsState < 0)
                pointsState = points.Length - 1;
        }
        #endregion
    }
}