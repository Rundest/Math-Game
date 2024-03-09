using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float mouseSensitivity;
    private float xRotation = 0;
    public float raycastLenght;
    [HideInInspector] public bool raycast;
    public RaycastHit raycastHit;

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 40);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        player.transform.Rotate(Vector3.up * mouseX);

        raycast = Physics.Raycast(gameObject.transform.position, transform.forward, out raycastHit, raycastLenght, LayerMask.GetMask("Math"));
    }
}
