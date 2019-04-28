using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillItem : MonoBehaviour
{
    public int playerId;

    public ArenaManager arenaManager;

    public int skillId;
    public int price;
    public bool isBought = false;
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = price.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void BuySkill()
    {
        if (!isBought)
        {
            if (playerId == 1 && arenaManager.pl1skillId == 0)
            {
                if (arenaManager.pl1Score >= price)
                {
                    arenaManager.pl1skillId = skillId;
                    arenaManager.pl1Score -= price;
                    arenaManager.pl1ScoreText.text = arenaManager.pl1Score.ToString();
                    GetComponent<Image>().color = new Color(0xFF / 255f, 0xD6 / 255f, 0x4C / 255f);
                    isBought = true;
                }
            }
            else if (playerId == 2 && arenaManager.pl2skillId == 0)
            {
                if (arenaManager.pl2Score >= price)
                {
                    arenaManager.pl2skillId = skillId;
                    arenaManager.pl2Score -= price;
                    arenaManager.pl2ScoreText.text = arenaManager.pl2Score.ToString();
                    GetComponent<Image>().color = new Color(0xFF / 255f, 0xD6 / 255f, 0x4C / 255f);
                    isBought = true;
                }
            }
        }
    }
}
