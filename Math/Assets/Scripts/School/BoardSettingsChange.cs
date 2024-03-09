using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoardSettingsChange : MonoBehaviour
{
    private CameraMovement cameraMovement;
    [SerializeField] private MaterialHolder materialHolder;
    [SerializeField] private GameObject[] allBoards;
    [SerializeField] private GameObject eText;
    [SerializeField] private MathSchool mathSchool;

    // Start is called before the first frame update
    void Start()
    {
        cameraMovement = GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraMovement.raycast)
        {
            mathSchool = cameraMovement.raycastHit.collider.GetComponent<MathSchool>();
            cameraMovement.raycastHit.collider.GetComponent<MeshRenderer>().materials = new Material[2] { materialHolder.outline, materialHolder.inside };
            eText.SetActive(true);
            eText.GetComponent<TextMeshProUGUI>().text = "Kliknij 'E' aby otworzyc panel matematyczny";
            mathSchool.enabled = true;
        }
        else
        {
            mathSchool.enabled = false;
            eText.SetActive(false);
            mathSchool = null;
        }

        if (mathSchool == null)
        {
            for (int i = 0; i < allBoards.Length; i++)
            {
                allBoards[i].GetComponent<MeshRenderer>().materials = new Material[2] { materialHolder.outside, materialHolder.inside };
            }
        }

    }
}
