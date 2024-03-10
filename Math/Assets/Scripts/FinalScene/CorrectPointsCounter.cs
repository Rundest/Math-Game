using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CorrectPointsCounter : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        if(gameObject.name == "CorrectAnswersLevel2")
        {
            text.text = "Poprawne odpowiedzi poziom 2: " + PointText.points;
        }
        else if (gameObject.name == "CorrectAnswersLevel1")
        {
            text.text = "Poprawne odpowiedzi poziom 1: " + MathManager.points;
        }
    }
}
