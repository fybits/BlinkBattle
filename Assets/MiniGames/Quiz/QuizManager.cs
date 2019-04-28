using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour {
    public Question[] quests;
    Stack<Question> questions = new Stack<Question>();

    public TextMeshProUGUI questionText;
    public GameObject answers;

    bool alloyInput = false;

    int player1Choice, player2Choice;

    private void Start() {
        for (int i = 0; i < quests.Length; i++) {
            questions.Push(quests[i]);
        }
    }


    IEnumerator Loop() {
        Question current = questions.Pop();
        questionText.text = current.question;
        TextMeshProUGUI[] variants = answers.GetComponentsInChildren<TextMeshProUGUI>();
        for (int i = 0; i < 4; i++) {

            yield return new WaitForSeconds(0.1f);
        }
        alloyInput = true;
    }
}
