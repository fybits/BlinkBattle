using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReadyButton : MonoBehaviour
{
    public bool state = false;
    TextMeshProUGUI text;
    public ArenaManager arenaManager;
    // Start is called before the first frame update
    void Start()
    {
        if (!arenaManager)
        {
            arenaManager = GameObject.FindGameObjectWithTag("ArenaManager").GetComponent<ArenaManager>();
        }

        if (!arenaManager.pl1ReadyButton)
        {
            arenaManager.pl1ReadyButton = GameObject.FindGameObjectWithTag("pl1Button").GetComponent<ReadyButton>();
        }

        if (!arenaManager.pl2ReadyButton)
        { 
            arenaManager.pl2ReadyButton = GameObject.FindGameObjectWithTag("pl2Button").GetComponent<ReadyButton>();
        }

        text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = "Ready";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        state = !state;
        Debug.Log("Click");
        if (state == true)
            text.text = "Not Ready";
        else
            text.text = "Ready";
    }
}
