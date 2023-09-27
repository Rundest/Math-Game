using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{  
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI mathText;

    public static UIManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this) 
        {
            Destroy(this);
        }
    }
}
