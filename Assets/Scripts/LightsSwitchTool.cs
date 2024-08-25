using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LightsSwitchTool : MonoBehaviour
{
    List<Light> lights;

    void Start()
    {
        lights = new List<Light>();
        foreach (Transform child in transform)
        {
            Debug.Log("Child Object: " + child.gameObject.name);
            lights.Add(child.gameObject.GetComponent<Light>());
            // Aquí puedes hacer lo que necesites con cada hijo.
        }

    }
    public void ChangeLights(Color colorlight)
    {
        foreach (Light child in lights)
        {
            child.color = colorlight;
        }
    }
}
