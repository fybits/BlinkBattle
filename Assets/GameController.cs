using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    enum GameState { MainMenu, MiniGames, Arena }
    GameState state = GameState.MainMenu;
    bool stateChanged = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stateChanged) {
            switch (state) {
                case GameState.MainMenu:
                    SceneManager.LoadScene("MainMenu");
                    break;
            }

        }
    }
}
