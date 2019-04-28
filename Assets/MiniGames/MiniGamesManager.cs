using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGamesManager : MonoBehaviour
{
    public MiniGame[] miniGamesPool;

    Stack<MiniGame> miniGames = new Stack<MiniGame>();

    public static MiniGamesManager singleton;

    bool isPlaying = false;

    private void Awake() {
        singleton = this;
    }

    // Start is called before the first frame update
    void Start() {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        for (int i = 0; i < 5; i++) {
            miniGames.Push(miniGamesPool[Random.Range(0, miniGamesPool.Length)]);
        }
        StartCoroutine("NextGame");
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1) {
        if (arg0.name == "MiniGames") {
            StartCoroutine("NextGame");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    

    public void EndMiniGame() {
        SceneManager.LoadScene("MiniGames");
    }


    IEnumerator NextGame() {
        isPlaying = true;
        if (miniGames.Count > 0) {
            MiniGame nextGame = miniGames.Pop();
            Debug.Log(miniGames.Count);
            UIManager.singleton.ShowGameInfo(nextGame);
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(nextGame.SceneName, LoadSceneMode.Single);
        } else {
            GameController.singleton.SetState((int)GameController.GameState.Arena);
        }
    }
}
