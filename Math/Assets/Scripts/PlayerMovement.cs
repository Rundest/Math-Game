using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float playerSpeed = 12f;

    [SerializeField] private Transform groundCheck;

    [SerializeField] private float groundDistance = 0.4f;

    [SerializeField] private LayerMask groundMask;

    bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float x = Input.GetAxis("Horizontal");

        float z = Input.GetAxis("Vertical");

        float xMovement = x * playerSpeed * Time.deltaTime;

        float zMovement = z * playerSpeed * Time.deltaTime;

        transform.Translate(xMovement, 0, zMovement);
    }
}
