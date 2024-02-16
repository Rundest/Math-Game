using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MathSchool : MonoBehaviour
{
    public CameraMovement playerCam;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject mathPanel;
    [SerializeField] private PointText pointText;
    public MathProblemsSO mathProblem;
    [SerializeField] private AnswerSO answersSO;
    [SerializeField] private TextMeshProUGUI question;
    public Button[] answers;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MathSchool>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (ActivePanelCheck() == false)
        {
            OpenPanel();
            SettingUpQuestionText();
            SettingUpButtonText();
        }
        else
        {
            ClosePanel();
        }

        Debug.Log(IsAnswered());
    }

    private bool ActivePanelCheck()
    {
        return mathPanel.activeInHierarchy ? true : false;
    }

    private void OpenPanel()
    {
        if (playerCam.raycast)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                mathPanel.SetActive(true);
                playerMovement.enabled = false;
                playerCam.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                TurnBackButtons();
            }
        }
    }


    private void ClosePanel()
    {
        if (playerCam.raycast)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                mathPanel.SetActive(false);
                playerMovement.enabled = true;
                playerCam.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                IsAnswered();
                ResetColors();
            }
        }
    }

    private void ResetColors()
    {
        for(int i = 0; i < answers.Length; i++)
        {
            answers[i].GetComponent<Image>().color = Color.white;
        }
    }

    private void TurnBackButtons()
    {
        for (int i = 0; i < answers.Length; i++)
        {
            answers[i].enabled = true;
        }
    }

    bool IsAnswered()
    {
        for (int i = 0; i < answers.Length; i++)
        {
            if(answers[i].GetComponent<Image>().color != Color.white)
            {
                gameObject.layer = 0;
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    private void SettingUpQuestionText()
    {
        question.text = mathProblem.question;
    }

    private void SettingUpButtonText()
    {
        for (int i = 0; i < answers.Length; i++)
        {
            answers[i].GetComponentInChildren<TextMeshProUGUI>().text = answersSO.answers[i].ToString();  
        }
    }
}
