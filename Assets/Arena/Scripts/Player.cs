using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerNum;

    public float health = 100;

    public Vector2 moveDir;
    public Vector2 viewDir;
    public Vector2 input;

    public Vector2 vel;
    public float speed;
    public float friction = 0.9f;
    public float defense = 1;

    public int weaponId = 0;
    public GameObject weapon;

    public int skillId = 0;
    public SkillBase skill;

    public GameObject shield;
    public GameObject particles;


    public ArenaManager arenaManager;
    public bool canMove = true;

    public float fireSpeed;
    public float fireSpeedTimer;
    // Start is called before the first frame update
    void Start()
    {
        arenaManager = FindObjectOfType<ArenaManager>();
        if (playerNum == 1)
        {
            GetComponent<Player>().skill = new ShieldSkill(GetComponent<Player>());
        }
        else
        {
            GetComponent<Player>().skill = new BlinkSkill(GetComponent<Player>());
        }

        vel = new Vector2();
        //skill = new BlinkSkill(this);

        Sprite playerSkin = Resources.Load<Sprite>("Arena/Sprites/Player/Player_" + playerNum.ToString());
        if (playerSkin)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = playerSkin;
        }

        if (playerNum == 1)
        {
            TakeWeapon(1);
        }
        else if (playerNum == 2)
        {
            TakeWeapon(1);
        }
        fireSpeed = weapon.GetComponent<Weapon>().fireSpeed;
        fireSpeedTimer = fireSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("ActionP" + playerNum)) {
            Debug.Log("Action pressed");
            skill.Cast();
            
        }

        if (arenaManager.gameEnded == false)
        {
            if (fireSpeedTimer > 0)
            {
                fireSpeedTimer -= Time.fixedDeltaTime;
            }

            if (fireSpeedTimer <= 0)
            {
                
                if (Input.GetButton("FireP" + playerNum))
                {
                    weapon.GetComponent<Weapon>().Fire();
                    fireSpeedTimer = fireSpeed;
                }
            }

            if (health <= 0)
            {
                if (arenaManager.gameEnded == false)
                {
                    arenaManager.EndGame(playerNum);
                    arenaManager.gameEnded = true;
                    gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Arena/Sprites/death");
                    gameObject.GetComponent<SpriteRenderer>().sortingOrder = 25;
                    canMove = false;
                    Destroy(GetComponent<CircleCollider2D>());
                }
            }      
        }
        if (canMove)
            Move();
    }

    public void Move()
    {
        input = new Vector2(Input.GetAxisRaw("HorizontalP" + playerNum),
                           Input.GetAxisRaw("VerticalP" + playerNum));
        
        if (input.magnitude >= 0.2f)
        {
            vel += input.normalized * speed * Time.fixedDeltaTime;
        }

        transform.position += new Vector3(vel.x, vel.y, 0);
        viewDir = new Vector2(Input.GetAxis("HorizontalViewP" + playerNum), Input.GetAxis("VerticalViewP" + playerNum));
        if (playerNum == 2)
        {
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
            int numOfGamepads = 0;
            for (int i = 0; i < Input.GetJoystickNames().Length; i++)
                if (!Input.GetJoystickNames()[i].Equals(""))
                    numOfGamepads++;
            if (numOfGamepads == 2) {
                if (viewDir.magnitude >= 0.2f) {
                    transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(viewDir.y, viewDir.x) * Mathf.Rad2Deg);
                } else if (input.magnitude >= 0.2f) {
                    transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg);
                }
            } else {
                viewDir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
                transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(viewDir.y, viewDir.x) * Mathf.Rad2Deg);
            }
        }
        
        //Debug.Log(viewDir.x.ToString() + " " + viewDir.y.ToString());

        vel *= friction;
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
