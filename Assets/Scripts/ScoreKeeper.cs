using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int CorectAnswers = 0;
    int QuestionsSceen = 0;
   
   public int GetCorrectAnswers()
   {
     return CorectAnswers;
   }

   public void IncrementCorrectAnswers()
   {
        CorectAnswers++;
   }
   public int GetQuestionSceen()
    {
        return QuestionsSceen;
           
    }
    public void IncrementQuestionsSceen()
    {
        QuestionsSceen++;
    }
    public int CalculateScrore()
    {
        return Mathf.RoundToInt(CorectAnswers / (float)QuestionsSceen * 100); //3/4
    }
}
