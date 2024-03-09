using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenVault : MonoBehaviour
{
    [SerializeField] private PickUpTablets pickUpTablets;
    [SerializeField] private float openSpeed;
    private float yMovementPositionVault;
    [SerializeField] private CloseFirstVault closeFirstVault;
    private float originalYPosition;

    private void Start()
    {
        originalYPosition = transform.position.y;
        yMovementPositionVault = transform.position.y + 2;

    }

    void Update()
    {
        if (pickUpTablets.iterator >= 4 && !closeFirstVault.isInTrigger)       
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, yMovementPositionVault, transform.position.z), Time.deltaTime * openSpeed);      
        else if (closeFirstVault.isInTrigger)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, originalYPosition, transform.position.z), Time.deltaTime * openSpeed);
    }
}
