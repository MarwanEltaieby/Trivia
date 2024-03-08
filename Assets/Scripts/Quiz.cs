using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO questionSO; 

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons = new GameObject[4];
    int correctAnswerIndex;
    
    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    Timer timer;

    private void Start() {
        timer = FindObjectOfType<Timer>();
        GetNextQuestion();
        //DisplayQuestion();
    }

    private void Update() {
        if(timer.GetLoadNextQuestion()) {
            GetNextQuestion();
            timer.SetLoadNextQuestion(false);
        } else if(!timer.GetIsAnsweringQuestion()) {
            
        }
    }

    private void DisplayQuestion() {
        questionText.text = questionSO.GetQuestion();
        for (int i = 0; i < answerButtons.Length; i++) {
            TMP_Text buttonText = answerButtons[i].GetComponentInChildren<TMP_Text>();
            buttonText.text = questionSO.GetChoice(i);
            SetButtonState(true);
        }
    }

    void GetNextQuestion() {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }

    public void OnAnswerSelected(int index) {
        if (index == questionSO.GetCorrectAnswerIndex()) {
            questionText.text = "Correct";
            Image buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        } else {
            index = questionSO.GetCorrectAnswerIndex();
            questionText.text = "Wrong";
            Image buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        SetButtonState(false);
        timer.CancelTimer();
    }

    void SetButtonState(bool state) {
        for(int i = 0; i < answerButtons.Length; i++) {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprites() {
        for(int i = 0; i < answerButtons.Length; i++) {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
