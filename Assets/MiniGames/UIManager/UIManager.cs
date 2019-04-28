using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI popup;
    public GameObject GameInfo;

    public static UIManager singleton;

    private void Awake() {
        singleton = this;
    }
    
    public void ShowGameInfo(MiniGame info) {
        GameInfo.SetActive(true);
        GameInfo.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = info.Name;
        GameInfo.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = info.Description;
    }

    public IEnumerator PopUp (object[] pars) {
        popup.gameObject.SetActive(true);
        popup.text = (string)pars[0];
        yield return new WaitForSeconds((float)pars[1]);
        popup.gameObject.SetActive(false);
    }
}
