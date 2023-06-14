using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questons")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    [Range(0, a)] int questionRange;
    QuestionSO currentQuestion; 
    const  int a = 0;
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
        int a = questions.Count;
        int time = questions.Count;
        timer = FindObjectOfType<Timer>();
        displayNextQuestion();
        // DisplayQuestions();
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
        if (index == currentQuestion.GetCorrectAswerIndex())
        {
            questionText.text = "Correct";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctAnswerIndex = currentQuestion.GetCorrectAswerIndex();
            string correctAnswer = currentQuestion.GetAnswer(correctAnswerIndex);
            questionText.text = "really really really. you die in a blase of blaster fire;\n" + correctAnswer;
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }

    void displayNextQuestion()
        {
            setAnswerButtons(true);
            SetDefaultSprite();
            GetNotRandomQuestion();
            DisplayQuestions();
        }
    void GetNotRandomQuestion()
        {
            int index  = questionRange;
            currentQuestion = questions[index];
            if(questions.Contains(currentQuestion))
            {
               questions.Remove(currentQuestion);
            }
        }

    void DisplayQuestions()
    {
        questionText.text = currentQuestion.GetQuestion();
        
        for(int i = 0; i < answerButtons.Length; i++)
        {
        TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = currentQuestion.GetAnswer(i);
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

