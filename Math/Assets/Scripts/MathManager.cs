using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MathManager : MonoBehaviour
{
    [SerializeField] private Animator trueAnsweranimator;
    [SerializeField] private Animator falseAnsweranimator;
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private TextMeshProUGUI mathText;
    [SerializeField] private MathProblemsSO[] mathProblems;
    [SerializeField] private GameObject[] answersOfObjects;
    private int iteration = 0;
    private float points = 0;

    // Start is called before the first frame update
    void Start()
    {
        mathText.text = mathProblems[iteration].question;
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = points.ToString();
    }

    private bool CheckIfCorrectAnswer(Animator answerAnimator)
    {
        foreach (var answers in answersOfObjects)
        {
            foreach (var problems in mathProblems)
            {
                if(problems.answer == GetAnswerFromObejcts(answerAnimator.gameObject))
                    return true;
            }
        }

        return false;
    }

    private float GetAnswerFromObejcts(GameObject answer)
    {
        Answer objectWithAnswer = new Answer();

        objectWithAnswer = answer.GetComponent<Answer>();

        return objectWithAnswer.answer;
    }

    private void ChangeMathText()
    {
        if (iteration >= mathProblems.Length - 1)
        {
            return;
        }
        else
        {
            iteration++;
            mathText.text = mathProblems[iteration].question;
        }
    }

    public IEnumerator Answer(Animator answerAnimator)
    {
        answerAnimator.SetTrigger("Activated");

        yield return new WaitForSecondsRealtime(2);

        if (CheckIfCorrectAnswer(answerAnimator))
        {
            mathText.color = Color.green;

            points++;
        }
        else
        {
            mathText.color = Color.red;
        }

        yield return new WaitForSecondsRealtime(2);

        answerAnimator.SetTrigger("DeActivated");

        mathText.color = Color.white;

        ChangeMathText();
    }
}
