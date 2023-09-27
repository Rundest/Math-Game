using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathManager : MonoBehaviour
{
    [SerializeField] private Animator trueAnsweranimator;
    [SerializeField] private Animator falseAnsweranimator;
    [SerializeField] private MathProblemsSO[] mathProblems;
    [SerializeField] private Answer[] answersOfObjects;
    private int iteration = 0;
    private float points = 0;

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.mathText.text = mathProblems[iteration].question;
    }

    private bool CheckIfCorrectAnswer(GameObject answerGameObject)
    {
        return mathProblems[iteration].answer == answerGameObject.GetComponent<Answer>().answer;
    }

    private void ChangeMathText()
    {
        if (iteration >= mathProblems.Length - 1) return;

        iteration++;
        UIManager.Instance.mathText.text = mathProblems[iteration].question;

    }

    public IEnumerator Answer(GameObject answerGameObject)
    {
        Animator answerAnimator = answerGameObject.GetComponent<Animator>();

        answerAnimator.SetTrigger(AnswerAnimations.activated);

        yield return new WaitForSecondsRealtime(2);

        if (CheckIfCorrectAnswer(answerGameObject))
        {
            UIManager.Instance.mathText.color = Color.green;

            points++;
        }
        else
        {
            UIManager.Instance.mathText.color = Color.red;
        }

        yield return new WaitForSecondsRealtime(2);

        UIManager.Instance.pointsText.text = points.ToString();

        answerAnimator.SetTrigger(AnswerAnimations.deActivated);

        UIManager.Instance.mathText.color = Color.white;

        ChangeMathText();
    }
}