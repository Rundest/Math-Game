using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSecondVault : MonoBehaviour
{
    [SerializeField] private MathManager mathManager;
    private float openSpeed = 3;
    private float yMovementPosition;

    private void Start()
    {
        yMovementPosition = transform.position.y + 2;
    }

    void Update()
    {
        int i = mathManager.iteration;
        if (i >= mathManager.mathProblems.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, yMovementPosition, transform.position.z), Time.deltaTime * openSpeed);
        }
    }
}