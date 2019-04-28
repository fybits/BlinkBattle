using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [HideInInspector]
    public float baseSpeed;
    public float speed;
    float rotationDir;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(Vector3.forward * Random.Range(0, 360));
        rotationDir = Random.Range(-5, 5) * baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed*Time.deltaTime, 0, 0, Space.World);
        transform.Rotate(Vector3.forward*rotationDir*Time.deltaTime);
    }
}
