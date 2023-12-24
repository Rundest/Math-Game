using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathManager : MonoBehaviour
{
    public MathProblemsSO[] mathProblems;
    [SerializeField] private Answer[] answersOfObjects;
    [SerializeField] private AnswerSO[] answerSO;
    [HideInInspector] public int iteration = 0;
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
        //if (iteration >= mathProblems.Length - 1) return;

        iteration++;
        UIManager.Instance.mathText.text = mathProblems[iteration].question;

    }

    private void ChangeAnswerText()
    {
        for(int i = 0; i < answersOfObjects.Length; i++)
            answersOfObjects[i].answer = answerSO[iteration - 1].answers[i];
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

        ChangeAnswerText();
    }
}