using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Sprite defaultAnswerSprite;
    void Start() 
    {
        displayNextQuestion();
        //DisplayQuestions();
    }
    Image buttonImage;

     public void OnAnswerSelected(int index)

        {
            
            if(index == question.GetCorrectAswerIndex())
            {
                questionText.text = "Correct";
                buttonImage = answerButtons[index].GetComponent<Image>();
                buttonImage.sprite = correctAnswerSprite;
                setAnswerButtons(false);
                
            }
            else
            {
                correctAnswerIndex = question.GetCorrectAswerIndex();
                string correctAnswer = question.GetAnswer(correctAnswerIndex);
                questionText.text = "really really really. you die in a blase of blaster fire;\n" + correctAnswer;
                buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
                buttonImage.sprite = correctAnswerSprite;
                setAnswerButtons(false);

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

