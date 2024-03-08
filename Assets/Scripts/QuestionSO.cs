using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string quesiton = "Enter new Question text here";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] [Range(0, 3)] int correctAnswerIndex;

    public string GetQuestion() {
        return quesiton;
    }

    public int GetCorrectAnswerIndex() {
        return correctAnswerIndex;
    }

    public string GetCorrectAnswer() {
        return answers[correctAnswerIndex];
    }

    public string GetChoice(int index) {
        return answers[index];
    }
}
