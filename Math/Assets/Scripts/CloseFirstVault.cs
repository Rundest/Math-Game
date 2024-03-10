using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseFirstVault : MonoBehaviour
{

    [SerializeField] private OpenVault openVault;
    [HideInInspector] public bool isInTrigger;
    [SerializeField] private GameObject waypoint;
    [SerializeField] private GoalText goalTextObject;
    [SerializeField] private GameObject pointText;

    private void Start()
    {
        isInTrigger = false;
    }

    private void Update()
    {
        Debug.Log(isInTrigger);
    }

    private void OnTriggerEnter(Collider other)
    {
        isInTrigger = true;
        waypoint.SetActive(false);
        StartCoroutine(goalTextObject.ChangeTextColor());
        pointText.SetActive(true);
    }

}

