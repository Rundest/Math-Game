using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Events : MonoBehaviour
{
    [SerializeField] private PickUpTablets pickup;
    [SerializeField] private GameObject player;
    [SerializeField] private Camera uiCamera;
    private Image image;
    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponentInChildren<Image>();
        rectTransform = GetComponent<RectTransform>();
        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (pickup.iterator >= 4)
        {
            image.enabled = true;

            float distance = Vector3.Distance(transform.position, player.transform.position);

            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

            if (distance < 5)
            {
                image.color = new Color(255, 255, 255, distance - 2);
            }

        }
    }
}
