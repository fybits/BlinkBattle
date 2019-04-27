using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReadyButton : MonoBehaviour
{
    public bool state = false;
    TextMeshProUGUI text;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        if (!gameManager)
        {
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }

        if (!gameManager.pl1ReadyButton)
        {
            gameManager.pl1ReadyButton = GameObject.FindGameObjectWithTag("pl1Button").GetComponent<Button>();
        }

        if (!gameManager.pl2ReadyButton)
        { 
            gameManager.pl2ReadyButton = GameObject.FindGameObjectWithTag("pl2Button").GetComponent<Button>();
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
