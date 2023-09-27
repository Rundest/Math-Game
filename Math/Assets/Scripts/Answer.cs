using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private MathManager manager;
    private Animator animator;
    public float answer;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == player.GetComponent<CapsuleCollider>())
        {
            StartCoroutine(manager.Answer(gameObject));
        }
    }
}
