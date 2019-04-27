using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketRaceManager : MonoBehaviour
{
    float timeFromStart = 0;
    public GameObject stars;
    public Transform obstaclesPlaceHolder;
    public GameObject[] obstacles;
    bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        timeFromStart = 15;
    }

    private void FixedUpdate() {
        Time.timeScale = 1 + timeFromStart * 0.05f;
        Debug.Log(Time.timeScale);

        if (Time.timeScale < 95)
            timeFromStart += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Round(timeFromStart%2) == 0) {
            if (!spawned) {
                GameObject goToSpawn = obstacles[Random.Range(0, obstacles.Length)];
                Obstacle obstacle = Instantiate(goToSpawn, obstaclesPlaceHolder).GetComponent<Obstacle>();
                float startHeight = Random.Range(Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y,
                                                 Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y);

                obstacle.transform.position = new Vector3(Random.Range(obstacle.transform.position.x, obstacle.transform.position.x + 5), startHeight, 0);
                obstacle.speed = 5 + Random.Range(-0.5f, 0.5f);
                spawned = true;
            }
        } else {
            spawned = false;
        }

        
    }
}
