using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    private GameObject player;
    private GameObject teleportIfBugged;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private CameraMovement cameraMovement;

    private void Start()
    {
        player = GameObject.Find("Player");
        teleportIfBugged = GameObject.Find("TeleportIfBugged");
        playerMovement = player.GetComponent<PlayerMovement>();
        cameraMovement = player.GetComponentInChildren<CameraMovement>();
    }

    private void Update()
    {
        if(parent.activeInHierarchy == false && Input.GetKeyDown(KeyCode.Escape))
        {
            parent.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            playerMovement.enabled = false;
            cameraMovement.enabled = false;
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerMovement.enabled = true;
        cameraMovement.enabled = true;
        parent.SetActive(false);
    }

    public void UnBug()
    {
        player.transform.position = teleportIfBugged.transform.position;
        Cursor.lockState = CursorLockMode.Locked;
        playerMovement.enabled = true;
        cameraMovement.enabled = true;
        parent.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
