using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletId;
    public int playerId;

    public int damage;
    public float speed = 1;
    public Vector2 movDir;

    public float timeToDestroy = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
        movDir = movDir.normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(movDir.x, movDir.y, 0) * speed * Time.fixedDeltaTime;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject col = collision.gameObject;
        if (playerId == 1 && collision.gameObject.tag == "Player2")
        {
            col.GetComponent<Player>().health -= damage;
        }
        else if (playerId == 2 && collision.gameObject.tag == "Player1")
        {
            Debug.Log("HIT");
            col.GetComponent<Player>().health -= damage;
        }

        if (!(playerId == 2 && collision.gameObject.tag == "Player2" || playerId == 1 && collision.gameObject.tag == "Player1"))
            Destroy(gameObject);
    }
}
