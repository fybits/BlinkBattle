using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManagerInGame : MonoBehaviour
{
    public TextMeshProUGUI popup;
    public GameObject resultTable;

    public static UIManagerInGame singleton;

    private void Awake() {
        singleton = this;
    }

    public IEnumerator PopUp (object[] pars) {
        popup.gameObject.SetActive(true);
        popup.text = (string)pars[0];
        yield return new WaitForSeconds((float)pars[1]);
        popup.gameObject.SetActive(false);
    }

    public void ShowResults(int first, int firstExtra, int second, int secondExtra) {
        resultTable.SetActive(true);
        resultTable.transform.Find("first").GetComponent<TextMeshProUGUI>().text = "+" + first;
        resultTable.transform.Find("second").GetComponent<TextMeshProUGUI>().text = "+" + second;
        resultTable.transform.Find("firstExtra").GetComponent<TextMeshProUGUI>().text = "+" + firstExtra;
        resultTable.transform.Find("secondExtra").GetComponent<TextMeshProUGUI>().text = "+" + secondExtra;
    }
}
