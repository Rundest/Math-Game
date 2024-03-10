using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpTablets : MonoBehaviour
{
    [SerializeField] private GameObject[] tabletImages;
    private RawImage rawImage;
    public int iterator;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        tabletImages[iterator - 1].TryGetComponent<RawImage>(out RawImage image);
        rawImage = image;
        switch (iterator)
        {
            case 1:
                rawImage.color = Color.black;
                break;
            case 2:
                rawImage.color = Color.black;
                break;
            case 3:
                rawImage.color = Color.black;
                break;
            case 4:
                rawImage.color = Color.black;
                break;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        IPickable pickable = other.GetComponent<IPickable>();

        if (pickable != null)
        {
            iterator++;
            pickable.PickUpTablet();
        }
    }
}
