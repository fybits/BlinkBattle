using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public int playerNum;
    public float maxSpeed = 1;

    public GameObject ghost;

    Vector2 vel;
    // Start is called before the first frame update
    void Start()
    {
        Sprite playerSkin = Resources.Load<Sprite>("MiniGames/RocketRace/Sprites/Rocket_" + playerNum);
        if (playerSkin) {
            gameObject.GetComponent<SpriteRenderer>().sprite = playerSkin;
            ghost.GetComponent<SpriteRenderer>().sprite = playerSkin;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("HorizontalP" + playerNum) * 6f,
                                    Input.GetAxisRaw("ActionP" + playerNum) * 0.9f);
        if (Mathf.Abs(input.x) < 0.005)
            input.x = 0;
        vel += (input + Vector2.down * 0.35f) * Time.deltaTime;

        vel = Vector2.ClampMagnitude(vel, maxSpeed/5);

        if (vel.x > 0) {
            float distance = Mathf.Abs(transform.position.x - Camera.main.ViewportToWorldPoint(new Vector3(0.4f, 0, 0)).x);
            vel.x *= 1 - 1 / (distance * distance);
        }
        if (vel.x < 0) {
            float distance = Mathf.Abs(transform.position.x - Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x);
            vel.x *= 1 - 1 / (distance * distance);
        }

        Vector3 newPos = transform.position + new Vector3(vel.x, vel.y, 0);

        if (newPos.x < Camera.main.ViewportToWorldPoint(new Vector3(0.05f, 0, 0)).x)
            newPos.x = Camera.main.ViewportToWorldPoint(new Vector3(0.05f, 0, 0)).x;


        if (newPos.x > Camera.main.ViewportToWorldPoint(new Vector3(0.4f, 0, 0)).x)
            newPos.x = Camera.main.ViewportToWorldPoint(new Vector3(0.4f, 0, 0)).x;

        
        if (newPos.y > Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y)
            newPos.y = Camera.main.ViewportToWorldPoint(Vector3.zero).y;

        if (newPos.y < Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y)
            newPos.y = Camera.main.ViewportToWorldPoint(Vector3.one).y;

        if (newPos.y > Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 0)).y)
            ghost.transform.position = new Vector3(transform.position.x, transform.position.y - Camera.main.orthographicSize * 2.0f, 0);

        if (newPos.y < Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 0)).y)
            ghost.transform.position = new Vector3(transform.position.x, transform.position.y + Camera.main.orthographicSize * 2.0f, 0);

        transform.position = newPos;
        vel.x *= 0.5f;
    }
}
