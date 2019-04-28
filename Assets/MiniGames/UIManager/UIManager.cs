using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI popup;

    public static UIManager singleton;

    private void Awake() {
        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PopUp (object[] pars) {
        popup.gameObject.SetActive(true);
        popup.text = (string)pars[0];
        yield return new WaitForSeconds((float)pars[1]);
        popup.gameObject.SetActive(false);
    }
}
