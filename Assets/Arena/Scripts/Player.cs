using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int id;

    
    Vector2 moveDir;
    Vector2 viewDir;

    Vector2 vel;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Sprite playerSkin = Resources.Load<Sprite>("Arena/Sprites/Player/player_" + id.ToString());
        if (playerSkin)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = playerSkin;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
    }
}
