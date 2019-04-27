using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerNum;

    public int Health = 100;

    Vector2 moveDir;
    Vector2 viewDir;

    Vector2 vel;
    public float speed;

    public int weaponId = 0;
    public Weapon weapon;
    public GameObject arenaManager;

    // Start is called before the first frame update
    void Start()
    {
        arenaManager = FindObjectOfType<ArenaManager>().gameObject;

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
        if (Input.GetAxis("FireP" + playerNum) > 0)
        {
            weapon.Fire();
        }
        Move();
    }

    public void Move()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("HorizontalP" + playerNum),
                           Input.GetAxisRaw("VerticalP" + playerNum));

        if (input.magnitude >= 0.2f)
        {
            vel += input * speed * Time.deltaTime;
        }

        transform.position += new Vector3(vel.x, vel.y, 0);

        viewDir = new Vector2(Input.GetAxis("HorizontalViewP" + playerNum), Input.GetAxis("VerticalViewP" + playerNum));

        if (viewDir.magnitude >= 0.2f)
        {
            transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(viewDir.y, viewDir.x) * Mathf.Rad2Deg);
        }
        else if (input.magnitude >= 0.2f)
        {
            transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg);
        }

        Debug.Log(viewDir.x.ToString() + " " + viewDir.y.ToString());

        vel *= 0.9f;
    }

    public void TakeWeapon(int weaponId)
    {
        Weapon[] weaponList = arenaManager.GetComponent<ArenaManager>().weapons;
        if (weaponId > 0 && weaponId <= weaponList.Length)
        {
            weapon = weaponList[weaponId - 1];
        }
        else
        {
            weapon = weaponList[0];
        }
        Instantiate(weapon, transform);
    }
}
