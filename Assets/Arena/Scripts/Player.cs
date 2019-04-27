using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerNum;

    public int health = 100;

    public Vector2 moveDir;
    public Vector2 viewDir;
    public Vector2 input;

    Vector2 vel;
    public float speed;

    public int weaponId = 0;
    public GameObject weapon;
    public ArenaManager arenaManager;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        arenaManager = FindObjectOfType<ArenaManager>();
        gameManager = FindObjectOfType<GameManager>();
        vel = new Vector2();

        Sprite playerSkin = Resources.Load<Sprite>("Arena/Sprites/Player/Player_" + playerNum.ToString());
        if (playerSkin)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = playerSkin;
        }

        TakeWeapon(weaponId);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.gameEnded == false)
        {
            if (Input.GetAxis("FireP" + playerNum) > 0)
            {
                weapon.GetComponent<Weapon>().Fire();
            }

            if (health <= 0)
            {
                if (gameManager.gameEnded == false)
                {
                    gameManager.EndGame(playerNum);
                    gameManager.gameEnded = true;
                }
            }


            Move();
        }
    }

    public void Move()
    {
        input = new Vector2(Input.GetAxisRaw("HorizontalP" + playerNum),
                           Input.GetAxisRaw("VerticalP" + playerNum));

        if (input.magnitude >= 0.2f)
        {
            vel += input * speed * Time.deltaTime;
        }

        transform.position += new Vector3(vel.x, vel.y, 0);

        if (playerNum == 2)
        {
            viewDir = new Vector2(Input.GetAxis("HorizontalViewP" + playerNum), Input.GetAxis("VerticalViewP" + playerNum));
            if (viewDir.magnitude >= 0.2f)
            {
                transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(viewDir.y, viewDir.x) * Mathf.Rad2Deg);
            }
            else if (input.magnitude >= 0.2f)
            {
                transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg);
            }
        }
        else if (playerNum == 1)
        {
            viewDir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(viewDir.y, viewDir.x) * Mathf.Rad2Deg);
        }

    

        //Debug.Log(viewDir.x.ToString() + " " + viewDir.y.ToString());

        vel *= 0.9f;
    }

    public void TakeWeapon(int weaponId)
    {
        GameObject[] weaponList = arenaManager.weapons;
        GameObject weaponToSpawn;
        if (weaponId > 0 && weaponId <= weaponList.Length)
        {
            weaponToSpawn = weaponList[weaponId - 1];
        }
        else
        {
            weaponToSpawn = weaponList[0];
        }
        weapon = Instantiate(weaponToSpawn, new Vector3(transform.position.x + 0.25f, transform.position.y, 0), transform.rotation, transform) as GameObject;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
      
    }
}
