using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToAnotherLever : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("School");
    }
}
