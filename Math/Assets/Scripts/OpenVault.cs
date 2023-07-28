using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenVault : MonoBehaviour
{
    [SerializeField] private PickUpTablets pickUpTablets;
    [SerializeField] private GameObject vaultEndPoint;
    [SerializeField] private float openSpeed;

    void Update()
    {
        if(pickUpTablets.tabletCount >= 4)
        {
            Debug.Log("Moving");
            transform.position = Vector3.MoveTowards(transform.position, vaultEndPoint.transform.position, Time.deltaTime * openSpeed);
        }
    }
}
