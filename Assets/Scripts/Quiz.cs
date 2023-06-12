using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questons")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnswerdEarly;
    [Header("Sprites")]
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Sprite defaultAnswerSprite;
    [Header("Timer")]
    [SerializeField] Image timerImage;

    Timer timer;
    void Start() 
    {
        timer = FindObjectOfType<Timer>();
        //displayNextQuestion();
        DisplayQuestions();
    }
    private void Update() 
    {
        timerImage.fillAmount = timer.fillFraction;
        if(timer.loadNextQuestion)
        {
            hasAnswerdEarly = false;
            displayNextQuestion();
            timer.loadNextQuestion = false;
        } 
        else if (!hasAnswerdEarly && !timer.isAnsweringQuestion)
        {
            displayAnswer(-1);
            setAnswerButtons(false);
        }
    }
    Image buttonImage;

     public void OnAnswerSelected(int index)

    {
        hasAnswerdEarly = true;
        displayAnswer(index);
        setAnswerButtons(false);
        timer.CancelTimer();
    }

    private void displayAnswer(int index)
    {
        if (index == question.GetCorrectAswerIndex())
        {
            questionText.text = "Correct";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctAnswerIndex = question.GetCorrectAswerIndex();
            string correctAnswer = question.GetAnswer(correctAnswerIndex);
            questionText.text = "really really really. you die in a blase of blaster fire;\n" + correctAnswer;
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }

    void displayNextQuestion()
        {
            setAnswerButtons(true);
            SetDefaultSprite();
            DisplayQuestions();
        }

    void DisplayQuestions()
    {
        questionText.text = question.GetQuestion();
        
        for(int i = 0; i < answerButtons.Length; i++)
        {
        TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = question.GetAnswer(i);
        }
    }
    void setAnswerButtons(bool State)
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = State;
        }
    }
    void SetDefaultSprite()
    {
       for(int i = 0; i < answerButtons.Length; i++)
       {
            buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
       }
    }
}

