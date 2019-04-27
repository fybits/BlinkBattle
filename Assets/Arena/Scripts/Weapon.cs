using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int weaponId;

    public byte bullets;
    public float spread;
    public float accuracy;
    public int fireSpeed;

    public GameObject bullet;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject;
        Sprite weaponSkin = Resources.Load<Sprite>("Arena/Sprites/Weapons/Weapon_" + weaponId.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fire()
    {
        // Debug.Log(transform.position);
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;

        float angle = player.transform.eulerAngles.z;

        int coef = 1;
        if (angle < 0)
            coef = -1;
        
        Vector2 plMovDir = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad) * coef, Mathf.Sin(angle * Mathf.Deg2Rad) * coef);
        newBullet.GetComponent<Bullet>().movDir = plMovDir;
        newBullet.GetComponent<Bullet>().playerId = player.GetComponent<Player>().playerNum;
    }
}
