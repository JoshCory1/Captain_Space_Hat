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
        questionText.text = question.GetQuestion();
        
        for(int i = 0; i < answerButtons.Length; i++)
        {
        TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = question.GetAnswer(i);
        }
    }

     public void OnAnswerSelected(int index)
        {
            Image buttonImage;
            if(index == question.GetCorrectAswerIndex())
            {
                questionText.text = "Correct";
                buttonImage = answerButtons[index].GetComponent<Image>();
                buttonImage.sprite = correctAnswerSprite;
                
            }
            else
            {
                correctAnswerIndex = question.GetCorrectAswerIndex();
                string correctAnswer =question.GetAnswer(correctAnswerIndex);
                questionText.text = "sorry, the correct answer was;\n" + correctAnswer;
                buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
                buttonImage.sprite = correctAnswerSprite;

            }
        }
}