using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReadyButton : MonoBehaviour
{
    public bool state = false;
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
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
