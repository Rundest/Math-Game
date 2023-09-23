using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectAnswer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private MathManager manager;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == player.GetComponent<CapsuleCollider>())
        {
            StartCoroutine(manager.CorrectAnswer());
        }
    }
}
