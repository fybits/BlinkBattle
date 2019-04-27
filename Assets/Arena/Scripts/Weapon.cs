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

    // Start is called before the first frame update
    void Start()
    {
        Sprite weaponSkin = Resources.Load<Sprite>("Arena/Sprites/Weapons/Weapon_" + weaponId.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fire()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, transform.parent.transform.rotation, transform) as GameObject;
        newBullet.GetComponent<Bullet>().movDir = new Vector2(transform.rotation.x, transform.rotation.y);
    }
}
