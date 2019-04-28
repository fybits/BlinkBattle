using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazookaBullet : MonoBehaviour
{
    public GameObject Explosion;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        int playerId = GetComponent<Bullet>().playerId;
        GameObject col = collision.gameObject;
        if (playerId == 1 && collision.gameObject.tag == "Player2") {
            Instantiate(Explosion, transform.position, Quaternion.identity);
        } else if (playerId == 2 && collision.gameObject.tag == "Player1") {
            Instantiate(Explosion, transform.position, Quaternion.identity);
        }
    }
}
