using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject trueAnswer;
    [SerializeField] private GameObject falseAnswer;
    [SerializeField] private float movingSpeed;
    [SerializeField] private Animator trueAnsweranimator;
    [SerializeField] private Animator falseAnsweranimator;
    private float points = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator CorrectAnswer()
    {
        trueAnsweranimator.SetTrigger("Activated");

        yield return new WaitForSecondsRealtime(2);

        points++;

        trueAnsweranimator.SetTrigger("DeActivated");

        Debug.Log("Points: " + points);
    }

    public IEnumerator FalsetAnswer()
    {
        falseAnsweranimator.SetTrigger("Activated");

        yield return new WaitForSecondsRealtime(2);

        falseAnsweranimator.SetTrigger("DeActivated");

        Debug.Log("Points: " + points);
    }
}
