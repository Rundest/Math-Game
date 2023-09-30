using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ParentAnswerText : MonoBehaviour
{
    private TextMeshProUGUI answerText;
    private Answer answer;

    void Start()
    {
        answerText = GetComponentInChildren<TextMeshProUGUI>();
        answer = GetComponent<Answer>();
    }

    // Update is called once per frame
    void Update()
    {
        answerText.text = answer.answer.ToString();
    }
}
