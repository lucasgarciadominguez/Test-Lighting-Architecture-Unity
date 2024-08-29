using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LightsSwitchTool : MonoBehaviour   //tool for switching lights color in the scene for realtime 
{
    List<Light> lights;

    void Start()
    {
        lights = new List<Light>();
        foreach (Transform child in transform)
        {
            lights.Add(child.gameObject.GetComponent<Light>());
        }

    }
    public void ChangeLights(Color colorlight)
    {
        foreach (Light child in lights)
        {
            child.color = colorlight;   //changes all lights
        }
    }
}
