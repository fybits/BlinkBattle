using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pl1;
    public GameObject pl2;

    public Button pl1ReadyButton;
    public Button pl2ReadyButton;
    public Button endGameButton;

    public int pl1Score;
    public int pl2Score;

    public bool arenaLoaded = false;
    public bool gameEnded = false;
    public GameObject winText;
    public Transform canvas;

    public Transform floor;
    public GameObject[] floorItems;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (arenaLoaded == false && pl1ReadyButton.GetComponent<ReadyButton>().state == true 
            && pl2ReadyButton.GetComponent<ReadyButton>().state == true)
        {
            LoadFight();
            arenaLoaded = true;
        }
    }

    void LoadFight()
    {
        // Terrain
        float lBound = -15;
        float tBound = 15;
        float step = 0.75f;

        for (float i = lBound; i < tBound; i += step)
        {
            for (float j = lBound; j < tBound; j += step)
            {
                if (i == lBound || i == tBound - step || j == lBound || j == tBound - step)
                {
                    Instantiate(floorItems[1], new Vector3(i, j, 0), Quaternion.identity, floor);
                }
                else
                {
                    Instantiate(floorItems[0], new Vector3(i, j, 0), Quaternion.identity, floor);
                }
            }
        }

        // Players
        Vector3 pl1SpawnPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.25f, Screen.height * 0.5f, 0));
        Vector3 pl2SpawnPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.75f, Screen.height * 0.5f, 0));

        pl1SpawnPos.z += 10;
        pl2SpawnPos.z += 10;

        pl1ReadyButton.gameObject.SetActive(false);
        pl2ReadyButton.gameObject.SetActive(false);

        Instantiate(pl1, pl1SpawnPos, Quaternion.identity);
        Instantiate(pl2, pl2SpawnPos, Quaternion.identity);
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
