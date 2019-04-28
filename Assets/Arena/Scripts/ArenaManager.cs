using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ArenaManager : MonoBehaviour
{
    public GameObject[] weapons;
    public GameObject[] skills;

    public GameObject pl1;
    public GameObject pl2;

    public CameraController cam;

    public GameObject BlackBackground;
    public GameObject FightSign;

    // Player items
    public int pl1weaponId = 0;
    public int pl1skillId = 0;
    public int pl2weaponId = 0;
    public int pl2skillId = 0;

    public GameObject plShop;
    public Button pl1ReadyButton;
    public Button pl2ReadyButton;
    public Button endGameButton;

    public int pl1Score;
    public int pl2Score;
    public TextMeshProUGUI pl1ScoreText;
    public TextMeshProUGUI pl2ScoreText;

    public bool arenaLoaded = false;
    public bool gameEnded = false;
    public GameObject winText;
    public Transform canvas;

    public Transform floor;
    public GameObject[] floorItems;

    // Start is called before the first frame update
    void Start()
    {
        if (GameController.singleton)
        {
            pl1Score = GameController.singleton.GetMoney().Item1;
            pl2Score = GameController.singleton.GetMoney().Item2;
        }
        else
        {
            pl1Score = 101;
            pl2Score = 101;
        }
        pl1ScoreText.text = pl1Score.ToString();
        pl2ScoreText.text = pl2Score.ToString();
    }

    // Update is called once per frame
    void Update()
    { 

        if (arenaLoaded == false && pl1ReadyButton.GetComponent<ReadyButton>().state == true
            && pl2ReadyButton.GetComponent<ReadyButton>().state == true)
        {
            plShop.SetActive(false);
            if (BlackBackground.GetComponent<SpriteRenderer>().color.a > 0) {
                BlackBackground.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.01f);
                Debug.Log("loop");
            }
            else
            {
                BlackBackground.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
                LoadFight();
                arenaLoaded = true;
            }
        }
    }

  

    private void LoadFight()
    {
        // Terrain
        //float lBound = -15;
        //float tBound = 15;
        //float step = 0.75f;

        //for (float i = lBound; i < tBound; i += step)
        //{
        //    for (float j = lBound; j < tBound; j += step)
        //    {
        //        if (i == lBound || i == tBound - step || j == lBound || j == tBound - step)
        //        {
        //            Instantiate(floorItems[1], new Vector3(i, j, 0), Quaternion.identity, floor);
        //        }
        //        else
        //        {
        //            Instantiate(floorItems[0], new Vector3(i, j, 0), Quaternion.identity, floor);
        //        }
        //    }
        //}

        // Players

        Vector3 pl1SpawnPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.25f, Screen.height * 0.5f, 0));
        Vector3 pl2SpawnPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.75f, Screen.height * 0.5f, 0));

        pl1SpawnPos.z += 10;
        pl2SpawnPos.z += 10;

        FightSign.SetActive(true);
        Destroy(FightSign, 2f);

        GameObject player1 = Instantiate(pl1, pl1SpawnPos, Quaternion.identity) as GameObject;
        GameObject player2 = Instantiate(pl2, pl2SpawnPos, Quaternion.identity) as GameObject;

        cam.pl1 = player1;
        cam.pl2 = player2;
        cam.initialDistance = Vector3.Distance(player1.transform.position, player2.transform.position);
    }

    public void EndGame(int playerNum)
    {
        int playerWinNum = 1;
        if (playerNum == 1)
        {
            playerWinNum = 2;
        }
        Vector2 spawnPos = new Vector2(0, 95);
        winText.GetComponent<TextMeshProUGUI>().text = "Player " + playerWinNum + " Wins!";
        winText.SetActive(true);
        endGameButton.gameObject.SetActive(true);
    }


    public void Retry()
    {
        // Reset GameManager
        pl1Score = 0;
        pl2Score = 0;
        arenaLoaded = false;
        gameEnded = false;

        SceneManager.LoadScene(0);
    }
}
