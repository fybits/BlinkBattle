using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WeaponItem : MonoBehaviour
{
    public int playerId;
    public Image image;

    public ArenaManager arenaManager;

    int weaponId;
    int price;
    public bool isBought = false;
    // Start is called before the first frame update
    void Start()
    {
        weaponId = Random.Range(0, arenaManager.weapons.Length);
        price = arenaManager.weapons[weaponId].GetComponent<Weapon>().price;

        Sprite sprite = arenaManager.weapons[weaponId].GetComponent<SpriteRenderer>().sprite;
        TextMeshProUGUI text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = price.ToString();
        image.sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BuyWeapon()
    {
        if (!isBought)
        {
            if (playerId == 1 && arenaManager.pl1weaponId == 0)
            {
                if (arenaManager.pl1Score >= price)
                {
                    arenaManager.pl1weaponId = weaponId;
                    arenaManager.pl1Score -= price;
                    arenaManager.pl1ScoreText.text = arenaManager.pl1Score.ToString();
                    GetComponent<Image>().color = new Color(0xFF / 255f, 0xD6 / 255f, 0x4C / 255f);
                    isBought = true;
                }
            }
            else if (playerId == 2)
            {
                if (arenaManager.pl2Score >= price && arenaManager.pl2weaponId == 0)
                {
                    arenaManager.pl2weaponId = weaponId;
                    arenaManager.pl2Score -= price;
                    arenaManager.pl2ScoreText.text = arenaManager.pl2Score.ToString();
                    GetComponent<Image>().color = new Color(0xFF/255f, 0xD6/255f, 0x4C/255f);
                    isBought = true;
                }
            }
        }
    }
}
