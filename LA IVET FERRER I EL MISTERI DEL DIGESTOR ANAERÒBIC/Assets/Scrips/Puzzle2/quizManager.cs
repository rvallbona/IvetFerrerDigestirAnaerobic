using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class quizManger : MonoBehaviour
{

    public int quizSolved = 0;
    [SerializeField]private int quizToResult;



    [SerializeField] private UnityEvent eventoFinQuiz;

    public void checkActivateButton()
    {
        if(quizSolved >= quizToResult)
        {

            eventoFinQuiz.Invoke();
        }
    }


    public void AddQuizCount()
    {
        quizSolved++;
    }
}
