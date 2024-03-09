using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassChoice : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    [SerializeField] private MathSchool[] school;
    [SerializeField] private CameraMovement playerCameraMovement;
    [SerializeField] private PlayerMovement playerMovement;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        playerMovement.enabled = false;
        playerCameraMovement.enabled = false;
    }

    public void OneTwoPressed()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerCameraMovement.enabled = true;
        playerMovement.enabled = true;
        parent.SetActive(false);
        return;
    }

    public void ThreeFourPressed()
    {
        Cursor.lockState = CursorLockMode.Locked;

        for(int i = 0; i < school.Length; i++)
        {
            school[i].mathProblem = school[i].mathProblemThreeFour;
            school[i].answersSO = school[i].answersSOThreeFour;
        }

        playerCameraMovement.enabled = true;
        playerMovement.enabled = true;

        parent.SetActive(false);

        return;
    }

}
