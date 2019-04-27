using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletId;

    public int damage;
    public float speed;
    public Vector2 movDir;

    // Start is called before the first frame update
    void Start()
    {
        movDir = movDir.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(movDir.x, movDir.y, 0) * speed;
    }
}
