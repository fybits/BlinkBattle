using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public enum GameState { MainMenu, MiniGames, Arena }
    GameState state = GameState.MainMenu;
    bool stateChanged = false;

    public static GameController singleton;

    int balance1 = 0;
    int balance2 = 0;

    private void Awake() {
        singleton = this;
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (stateChanged) {
            Debug.Log(stateChanged);
            switch (state) {
                case GameState.MainMenu:
                    SceneManager.LoadScene("MainMenu");
                    break;
                case GameState.MiniGames:
                    Debug.Log("Loading");
                    SceneManager.LoadScene("MiniGames");
                    break;
                case GameState.Arena:
                    SceneManager.LoadScene("ArenaScene");
                    break;
            }
            stateChanged = false;
        }
    }

    public void AddMoney(int money1,int money2) {
        balance1 += money1;
        balance2 += money2;
    }

    public void StartGame() {
        SceneManager.LoadScene("MiniGames");
    }

    public void SetState(int newState) {
        Debug.Log("new state is " + newState);
        state = (GameState)newState;
        stateChanged = true;
    }
}
