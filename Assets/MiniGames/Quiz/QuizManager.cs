using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour {
    public Question[] quests;
    Stack<Question> questions = new Stack<Question>();

    public TextMeshProUGUI questionText;
    public GameObject answers;

    Question current;

    bool alloyInput = false;

    int player1Score = 0, player2Score = 0;
    int player1Choice = -1, player2Choice = -1;

    private void Start() {
        for (int i = 0; i < quests.Length; i++) {
            questions.Push(new Question(quests[i].question,quests[i].answers,quests[i].correctAnswerId));
        }
        TextMeshProUGUI[] variants = answers.GetComponentsInChildren<TextMeshProUGUI>();
        for (int i = 0; i < 4; i++) {
            variants[i].gameObject.SetActive(false);
        }
    }


    private void Update() {
        if (alloyInput) {
            // Input
            // ABXY

            if (Input.GetButtonDown("AP1")) player1Choice = 0;
            if (Input.GetButtonDown("BP1")) player1Choice = 1;
            if (Input.GetButtonDown("XP1")) player1Choice = 2;
            if (Input.GetButtonDown("YP1")) player1Choice = 3;


            if (Input.GetButtonDown("AP2")) player2Choice = 0;
            if (Input.GetButtonDown("BP2")) player2Choice = 1;
            if (Input.GetButtonDown("XP2")) player2Choice = 2;
            if (Input.GetButtonDown("YP2")) player2Choice = 3;


            if (player1Choice != -1 && player2Choice != -1) {
                alloyInput = false;
                StartCoroutine(RevealRight());
            }
        }
    }

    IEnumerator ShowTask() {
        current = questions.Pop();
        questionText.text = current.question;
        TextMeshProUGUI[] variants = answers.GetComponentsInChildren<TextMeshProUGUI>();
        for (int i = 0; i < 4; i++) {
            variants[i].gameObject.SetActive(true);
            variants[i].text = current.answers[i];
            yield return new WaitForSeconds(0.1f);
        }
        alloyInput = true;
    }

    IEnumerator RevealRight() {
        yield return new WaitForSeconds(2);
        TextMeshProUGUI[] variants = answers.GetComponentsInChildren<TextMeshProUGUI>();
        for (int i = 0; i < 4; i++) {
            if (i == current.correctAnswerId)
                continue;
            variants[i].gameObject.SetActive(false);
        }
        variants[current.correctAnswerId].transform.parent.GetComponent<Image>().color = new Color(0, 0.8f, 0);
        if (player1Choice == current.correctAnswerId)
            player1Score++;
        if (player2Choice == current.correctAnswerId)
            player2Score++;
        yield return new WaitForSeconds(2);
        variants[current.correctAnswerId].gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        StartCoroutine(ShowTask());
    }
}
