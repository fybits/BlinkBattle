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

    public void ShowResults(int first, int second) {

    }
}
