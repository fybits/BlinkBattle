using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WeaponItem : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI text;

    public int playerId;
    public int weaponId;
    public int price;
    public Sprite sprite;

    public ArenaManager arenaManager;
    

    // Start is called before the first frame update
    void Start()
    {
        weaponId = Random.Range(1, arenaManager.weapons.Length + 1);
        price = arenaManager.weapons[weaponId].GetComponent<Weapon>().price;
        sprite = arenaManager.weapons[weaponId].GetComponent<SpriteRenderer>().sprite;
        text.text = price.ToString();
        button.gameObject.GetComponent<Image>().sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
