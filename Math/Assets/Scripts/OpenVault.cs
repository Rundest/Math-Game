using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenVault : MonoBehaviour
{
    [SerializeField] private PickUpTablets pickUpTablets;
    [SerializeField] private float openSpeed;
    private float yMovementPosition;

    private void Start()
    {
        yMovementPosition = transform.position.y + 2;
    }

    void Update()
    {
        if(pickUpTablets.tabletCount >= 4)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, yMovementPosition, transform.position.z), Time.deltaTime * openSpeed);
        }
    }
}
