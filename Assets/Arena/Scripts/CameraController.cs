using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject pl1;
    public GameObject pl2;

    public float initialDistance;

    public float smoothSpeed = 0.06f;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pl1 && pl2)
        {
            Vector3 desiredPosition = new Vector3((pl1.transform.position.x + pl2.transform.position.x) / 2, (pl1.transform.position.y + pl2.transform.position.y) / 2, -10);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            float currentDistanceX = Mathf.Abs(pl1.transform.position.x - pl2.transform.position.x);
            float currentDistanceY = Mathf.Abs(pl1.transform.position.y - pl2.transform.position.y);
            if ((currentDistanceX * 0.8f + currentDistanceY * 2.3f) / 2 > initialDistance * 0.75f)
            {
                float desiredSize = 5 * ((currentDistanceX * 0.8f + currentDistanceY * 2.3f) / 2) / (initialDistance * 0.75f);
                float smoothedSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, desiredSize, smoothSpeed);
                GetComponent<Camera>().orthographicSize = smoothedSize;
            }
        }
    }
}
