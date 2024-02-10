using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float mouseSensitivity;
    private float xRotation = 0;
    [SerializeField] private float raycastLenght;
    [HideInInspector] public bool raycast;
    public RaycastHit raycastHit;
    [SerializeField] private MathSchool mathSchool;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


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

        if (raycast)
        {
            mathSchool = raycastHit.collider.GetComponent<MathSchool>();
            mathSchool.enabled = true;
        }
        else
        {
            mathSchool.enabled = false;
            mathSchool = null;
        }
    }
}
