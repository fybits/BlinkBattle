using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public int playerNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = new Vector2(Input.GetAxisRaw("horizontalP" + playerNum),
                                    Input.GetAxisRaw("actionP" + playerNum)*2) * 0.5f;
        if (Mathf.Abs(vel.x) < 0.005)
            vel.x = 0;
        if (vel.y == 0)
            vel.y = -0.3f;

        Vector3 newPos = transform.position + new Vector3(vel.x, vel.y, 0);
        if (newPos.x < Camera.main.ViewportToWorldPoint(new Vector3(0.05f, 0, 0)).x)
            newPos.x = Camera.main.ViewportToWorldPoint(new Vector3(0.05f, 0, 0)).x;

        if (newPos.x > Camera.main.ViewportToWorldPoint(new Vector3(0.4f, 0, 0)).x)
            newPos.x = Camera.main.ViewportToWorldPoint(new Vector3(0.4f, 0, 0)).x;
        transform.position = newPos;
        vel.x *= 0.85f;
        Debug.Log(vel);
    }
}
