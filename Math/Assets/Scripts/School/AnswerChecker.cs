using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerChecker : MonoBehaviour
{
    [SerializeField] private PointText pointText;
    public MathSchool mathSchool;
    [SerializeField] private CameraMovement playerCameraMovement;
    private TextMeshProUGUI answer;
    [SerializeField] private TextMeshProUGUI goalsText;


    // Start is called before the first frame update
    void Start()
    {
        answer = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        playerCameraMovement = GameObject.FindObjectOfType<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCameraMovement.raycast)
        {
            mathSchool = playerCameraMovement.raycastHit.collider.gameObject.GetComponent<MathSchool>();
        }
    }

    public void ButtonClicked()
    {
        GoalText.iterator++;

        if (answer.text == mathSchool.mathProblem.answer.ToString())
        {
            PointText.points++;
        }

        for (int i = 0; i < mathSchool.answers.Length; i++)
        {
            mathSchool.answers[i].TryGetComponent<Image>(out Image answersColor);

            if (mathSchool.answers[i].GetComponentInChildren<TextMeshProUGUI>().text == mathSchool.mathProblem.answer.ToString())
            {
               answersColor.color = Color.green;
            }
            else
            {
                answersColor.color = Color.red;
            }
            mathSchool.answers[i].enabled = false;
        }

        goalsText.text = "Rozwiazane zadania: " + GoalText.iterator.ToString() + "/6";
    }
}
