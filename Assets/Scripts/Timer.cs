using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;
    float timerValue;
    bool isAnsweringQuestion = false;
    float fillFraction;
    bool loadNextQuestion;
    [SerializeField] Image timerImage;


    private void Update() {
        UpdateTimer();
    }

    public void CancelTimer() {
        timerValue = 0;
    }

    void UpdateTimer() {
        timerValue -= Time.deltaTime;

        if(timerValue <= 0) {
            if (isAnsweringQuestion) {
                timerValue = timeToShowCorrectAnswer;
                SetIsAnsweringQuestion(false);
            } else {
                loadNextQuestion = true;
                timerValue = timeToCompleteQuestion;
                SetIsAnsweringQuestion(true);
            }
        } else {
            if (isAnsweringQuestion) {
                fillFraction = timerValue/timeToCompleteQuestion;
            } else {
                fillFraction = timerValue/timeToShowCorrectAnswer;
            }
        }
        Debug.Log(fillFraction);
        timerImage.fillAmount = fillFraction;
    }

    public bool GetIsAnsweringQuestion() {
        return isAnsweringQuestion;
    }

    public void SetIsAnsweringQuestion(bool isAnsweringQuestion) {
        this.isAnsweringQuestion = isAnsweringQuestion;
    }

    public bool GetLoadNextQuestion() {
        return loadNextQuestion;
    }

    public void SetLoadNextQuestion(bool loadNextQuestion) {
        this.loadNextQuestion = loadNextQuestion;
    }
}
