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

    public TextMeshProUGUI[] variants;

    public TextMeshProUGUI player1Scr;
    public TextMeshProUGUI player2Scr;

    Question current;

    bool alloyInput = false;

    int player1Score = 0, player2Score = 0;
    int player1Choice = -1, player2Choice = -1;

    private void Start() {
        for (int i = 0; i < 5; i++) {
            questions.Push(new Question(quests[i].question,quests[i].answers,quests[i].correctAnswerId));
        }
        variants = answers.GetComponentsInChildren<TextMeshProUGUI>();
        for (int i = 0; i < 4; i++) {
            variants[i].gameObject.SetActive(false);
        }
        StartCoroutine(ShowTask());
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
                variants[player1Choice].text = "[1] "+ variants[player1Choice].text;
                variants[player2Choice].text += " [2]";
                alloyInput = false;
                StartCoroutine(RevealRight());
            }
        }
    }

    IEnumerator ShowTask() {
        if (questions.Count > 0) {
            current = questions.Pop();
            questionText.text = current.question;
            Debug.Log(variants.Length);
            string[] letters = { "A", "B", "X", "Y" };
            for (int i = 0; i < 4; i++) {
                yield return new WaitForSeconds(0.1f);
                variants[i].gameObject.SetActive(true);
                variants[i].text = letters[i]+" "+current.answers[i];
            }
            alloyInput = true;
        } else {
            if (player1Score > player2Score) {
                player1Score += 5;
            } else if (player2Score > player1Score)
                player2Score += 5;
            GameController.singleton.AddMoney(player1Score, player1Score);
            MiniGamesManager.singleton.EndMiniGame();
        }
    }

    IEnumerator RevealRight() {
        yield return new WaitForSeconds(2);
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
        player1Choice = -1;
        player2Choice = -1;
        player1Scr.text = "Player1\n" + player1Score;
        player2Scr.text = "Player2\n" + player2Score;
        yield return new WaitForSeconds(2);

        variants[current.correctAnswerId].transform.parent.GetComponent<Image>().color = new Color(1, 1, 1);
        variants[current.correctAnswerId].gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        StartCoroutine(ShowTask());
    }
}
