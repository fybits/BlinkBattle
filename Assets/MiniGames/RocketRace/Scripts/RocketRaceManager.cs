using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketRaceManager : MonoBehaviour
{
    public static RocketRaceManager singleton;

    float timeFromStart = 0;

    public GameObject playerGO;

    public GameObject stars;
    public Transform obstaclesPlaceHolder;
    public GameObject[] obstacles;

    List<GameObject> obstaclesList;

    bool spawned = false;

    Rocket player1;
    Rocket player2;
    Rocket player3;

    private void Awake() {
        singleton = this;
    }

    // Start is called before the first frame update
    public void Start()
    {
        obstaclesList = new List<GameObject>();
        timeFromStart = 15;
        Vector3 startPos = Camera.main.ViewportToWorldPoint(new Vector3(0.25f, 0.4f, 0));
        startPos.z = 0;
        GameObject player1go = Instantiate(playerGO, startPos, Quaternion.identity);
        player1 = player1go.GetComponent<Rocket>();
        player1.Init(1);
        startPos.y = 0.6f;
        GameObject player2go = Instantiate(playerGO, startPos, Quaternion.identity);
        player2 = player2go.GetComponent<Rocket>();
        player2.Init(2);
        startPos.y = 0.5f;
        //GameObject player3go = Instantiate(playerGO, startPos, Quaternion.identity);
        //player3 = player3go.GetComponent<Rocket>();
        //player3.Init(3);
        //player3.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1);
    }

    private void FixedUpdate() {
        float timeScale = 1 + timeFromStart * 0.05f;

        foreach(GameObject oGO in obstaclesList) {
            Obstacle o = oGO.GetComponent<Obstacle>();
            o.speed = o.baseSpeed * timeScale;
        }
        
        timeFromStart += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.isDead && player2.isDead) {// && player3.isDead) {
            Debug.Log("TIME: " + (timeFromStart - 15));
            SceneManager.LoadScene("rocketrace");
        }
        if (Mathf.Round(timeFromStart%2) == 0) {
            if (!spawned) {
                GameObject goToSpawn = obstacles[Random.Range(0, obstacles.Length)];
                Obstacle obstacle = Instantiate(goToSpawn, obstaclesPlaceHolder).GetComponent<Obstacle>();
                float startHeight = Random.Range(Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y,
                                                 Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y);

                obstacle.transform.position = new Vector3(Random.Range(obstacle.transform.position.x, obstacle.transform.position.x + 5), startHeight, 0);
                obstacle.baseSpeed = 5 + Random.Range(-0.5f, 0.5f);
                spawned = true;
                obstaclesList.Add(obstacle.gameObject);
            }
        } else {
            spawned = false;
        }

        if (obstaclesList.Count > 5) {
            GameObject go = obstaclesList[0];
            obstaclesList.RemoveAt(0);
            Destroy(go);
        }
    }
}
