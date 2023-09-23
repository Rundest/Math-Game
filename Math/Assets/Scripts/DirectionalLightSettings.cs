using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalLightSettings : MonoBehaviour
{
    void Start()
    {
        RenderSettings.ambientIntensity = 0f;
        RenderSettings.reflectionIntensity = 0f;

        RenderSettings.ambientIntensity = 1f;
        RenderSettings.reflectionIntensity = 1f;
    }
}
