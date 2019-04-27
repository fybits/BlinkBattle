using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketRaceManager : MonoBehaviour
{
    float timeFromStart = 0;
    public GameObject stars;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1 + timeFromStart / 20;
        Debug.Log(Time.timeScale);
        if (Time.timeScale < 95)
            timeFromStart += Time.deltaTime;
    }
}
