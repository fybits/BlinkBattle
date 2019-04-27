using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public int playerNum;
    Vector2 vel;
    public float maxSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("HorizontalP" + playerNum) * 2f,
                                    Input.GetAxisRaw("ActionP" + playerNum) * 0.5f);
        if (Mathf.Abs(input.x) < 0.005)
            input.x = 0;
        vel += (input + Vector2.down * 0.2f) * Time.deltaTime;

        vel = Vector2.ClampMagnitude(vel, maxSpeed/5);
        Vector3 newPos = transform.position + new Vector3(vel.x, vel.y, 0);
        if (newPos.x < Camera.main.ViewportToWorldPoint(new Vector3(0.05f, 0, 0)).x)
            newPos.x = Camera.main.ViewportToWorldPoint(new Vector3(0.05f, 0, 0)).x;

        if (newPos.x > Camera.main.ViewportToWorldPoint(new Vector3(0.4f, 0, 0)).x)
            newPos.x = Camera.main.ViewportToWorldPoint(new Vector3(0.4f, 0, 0)).x;

        transform.position = newPos;
        vel.x *= 0.5f;
        Debug.Log(vel);
    }
}
