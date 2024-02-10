using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointText : MonoBehaviour
{
    public int points;

    void Update()
    {
         gameObject.GetComponent<TextMeshProUGUI>().text = "Poprawne odpowiedzi: " + points.ToString();
    }
}
