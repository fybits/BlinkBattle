using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketRaceManager : MonoBehaviour
{
    float timeFromStart = 0;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {

        timeFromStart += Time.deltaTime;
    }
}
