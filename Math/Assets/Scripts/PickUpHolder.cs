using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHolder : MonoBehaviour
{
    private int pickUpCount;

    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.GetComponent<CapsuleCollider>() == other.gameObject.CompareTag("PickUp"))
        {
            pickUpCount++;
            Destroy(other.gameObject);
        }
    }
}
