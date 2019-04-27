using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pl1;
    public GameObject pl2;

    public Button pl1ReadyButton;
    public Button pl2ReadyButton;

    public int pl1Score;
    public int pl2Score;

    public bool arenaLoaded = false;
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
        Vector3 pl1SpawnPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.25f, Screen.height * 0.5f, 0));
        Vector3 pl2SpawnPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.75f, Screen.height * 0.5f, 0));

        Instantiate(pl1, pl1SpawnPos, Quaternion.identity ,null);
        Instantiate(pl2, pl2SpawnPos, Quaternion.identity, null);
    }
}
