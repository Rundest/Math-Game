using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GoalText : MonoBehaviour
{
    [HideInInspector] public TextMeshProUGUI goalText;
    [SerializeField] private BoxCollider closeFirstVault;
    [SerializeField] private string firstText;
    public int iterator = 0;

    // Start is called before the first frame update
    void Start()
    {
        goalText = GetComponent<TextMeshProUGUI>();
        goalText.text = firstText;
        goalText.color = Color.white;
    }

    private void Update()
    {
        if(iterator >= 6)
        {

        }
    }

    public IEnumerator ChangeTextColor()
    {
        goalText.color = Color.green;
        yield return new WaitForSeconds(1);
        goalText.color = Color.white;
        goalText.text = "Wejdz na plytki by zaznaczyc odpowiedz na podany problem matematyczny";
        closeFirstVault.enabled = false;
    }
}
