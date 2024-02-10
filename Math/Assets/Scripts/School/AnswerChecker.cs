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
        if (answer.text == mathSchool.mathProblem.answer.ToString())
        {
            pointText.points++;
        }

        for (int i = 0; i < mathSchool.answers.Length; i++)
        {
            if (mathSchool.answers[i].GetComponentInChildren<TextMeshProUGUI>().text == mathSchool.mathProblem.answer.ToString())
            {
                mathSchool.answers[i].GetComponent<Image>().color = Color.green;
            }
            else
            {
                mathSchool.answers[i].GetComponent<Image>().color = Color.red;
            }
            mathSchool.answers[i].GetComponent<Button>().enabled = false;
        }

    }
}
