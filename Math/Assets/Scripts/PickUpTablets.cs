using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpTablets : MonoBehaviour
{
    [HideInInspector] public int tabletCount = 0;
    [SerializeField] private GameObject[] tabletImages;

    private void Update()
    {
        switch(tabletCount) 
        { 
            case 1:
                tabletImages[0].GetComponent<RawImage>().color = Color.black;
                break;
            case 2:
                tabletImages[1].GetComponent<RawImage>().color = Color.black;
                break;
            case 3:
                tabletImages[2].GetComponent<RawImage>().color = Color.black;
                break;
            case 4:
                tabletImages[3].GetComponent<RawImage>().color = Color.black;

                break;
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        IPickable pickable = other.GetComponent<IPickable>();

        if(pickable != null )
        {
            tabletCount++;
            pickable.PickUpTablet();
        }
    }
}
