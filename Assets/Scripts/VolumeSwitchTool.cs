using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class VolumeSwitchTool : MonoBehaviour
{
    Volume volumeScene;

    void Start()
    {
        volumeScene = GetComponent<Volume>();   
    }
    public void ChangeVolumeProfile(VolumeProfile profile)
    {
        volumeScene.profile = profile;

    }
}
