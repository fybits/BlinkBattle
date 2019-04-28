using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public string question;
    public string[] answers;
    public int correctAnswerId;

    public Question(string question, string[] answers, int correctId) {
        this.question = question.ToUpper();
        this.answers = new string[4];
        for (int i = 0; i < 4; i ++) {
            this.answers[i] = answers[i].ToUpper();
        }
        this.correctAnswerId = correctId;
    }
}
