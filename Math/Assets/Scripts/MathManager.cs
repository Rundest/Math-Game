using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathManager : MonoBehaviour
{
    [SerializeField] private Image problemImage;
    [SerializeField] private GameObject tpObject;
    public MathProblemsSO[] mathProblems;
    [SerializeField] private Answer[] answersOfObjects;
    [SerializeField] private AnswerSO[] answerSO;
    [SerializeField] private ProblemsImageSO[] problemImageSO;
    [HideInInspector] public int iteration = 0;
    private GameObject player;
    public static float points = 0;

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.mathText.text = mathProblems[iteration].question;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        ChangeImage();
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
            answersOfObjects[i].answer = answerSO[iteration].answers[i];
    }

    private void TeleportToObjectAfterAnswering()
    {
        player.transform.position = tpObject.transform.position;
    }

    public IEnumerator Answer(GameObject answerGameObject)
    {
        Animator answerAnimator = answerGameObject.GetComponent<Animator>();

        answerAnimator.SetTrigger(AnswerAnimations.activated);

        TeleportToObjectAfterAnswering();

        player.GetComponent<PlayerMovement>().enabled = false;

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

        UIManager.Instance.pointsText.text = "Poprawne odpowiedzi: " + points.ToString();

        answerAnimator.SetTrigger(AnswerAnimations.deActivated);

        UIManager.Instance.mathText.color = Color.white;

        ChangeMathText();
        
        ChangeAnswerText();

        yield return new WaitForSecondsRealtime(1);

        player.GetComponent<PlayerMovement>().enabled = true;
    }

    void ChangeImage()
    {
        if(iteration == 2)
        {
            problemImage.sprite = problemImageSO[0].problemImage;
            problemImage.color = new Color(255, 255, 255, 255);
        }
        else if (iteration == 3)
        {
            problemImage.sprite = problemImageSO[1].problemImage;
            problemImage.color = new Color(255, 255, 255, 255);
        }
        else
        {
            problemImage.color = new Color(255, 255, 255, 0);
        }
    }
}