using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleatQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;

    public bool isAnsweringQuestion = false;

    float TimerValue;

    // Update is called once per frame
    void Update()
    {
        answerQuestionTimeer();
        updateTimer();
    }

    private void answerQuestionTimeer()
    {
        if(TimerValue <= 0 && isAnsweringQuestion)
        {
            isAnsweringQuestion = false;
            TimerValue = timeToShowCorrectAnswer;
        }

    }

    void updateTimer()
    {
        TimerValue -= Time.deltaTime;
        if(TimerValue <= 0 && !isAnsweringQuestion)
        {
            isAnsweringQuestion = true;
            TimerValue = timeToCompleatQuestion;
        }
        Debug.Log(TimerValue);
    }
}
