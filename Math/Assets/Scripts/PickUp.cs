using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour, IPickable
{
    public void PickUpTablet()
    {
        Destroy(gameObject);
    }
}
