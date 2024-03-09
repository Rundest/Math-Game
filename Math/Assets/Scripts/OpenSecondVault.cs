using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSecondVault : MonoBehaviour
{
    [SerializeField] private MathManager mathManager;
    [SerializeField] private GameObject mathText;
    [SerializeField] private GameObject[] answers;
    private GameObject player;
    private float openSpeed = 3;
    private float yMovementPosition;
    private float yMovementPositionAnswers;

    private void Start()
    {
        yMovementPosition = transform.position.y + 2;
        player = GameObject.FindGameObjectWithTag("Player");
        for (int i = 0; i < answers.Length; i++)
        {
            yMovementPositionAnswers = answers[i].transform.position.y - 5;
        }
    }

    void Update()
    {
        int i = mathManager.iteration;
        if (i >= mathManager.mathProblems.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, yMovementPosition, transform.position.z), Time.deltaTime * openSpeed);
            mathText.SetActive(false);
            player.GetComponent<PlayerMovement>().enabled = true;
            for (int j = 0; j < answers.Length; j++)
            {
                answers[j].transform.position = Vector3.MoveTowards(answers[j].transform.position, new Vector3(answers[j].transform.position.x, yMovementPositionAnswers, answers[j].transform.position.z), Time.deltaTime * 1.5f);
            }

        }
    }
}