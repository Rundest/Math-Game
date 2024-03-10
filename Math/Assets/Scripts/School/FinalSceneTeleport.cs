using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSceneTeleport : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (GoalText.iterator >= 6)
        {
            SceneManager.LoadScene("FinalScene");
        }
    }
}
