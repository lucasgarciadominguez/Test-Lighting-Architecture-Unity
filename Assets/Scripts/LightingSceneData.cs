using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


[CreateAssetMenu(fileName = "LightingSceneData", menuName = "Swapping Day and Night Cycles/LightingSceneData", order = 1)]

public class LightingSceneData : ScriptableObject
{
    [Header("Stored Light Map")]
    [SerializeField]
    public Texture2D l_Light;
    [SerializeField]
    public Texture2D l_Dir;

    [Header("Stored Reflection Probes")]
    [SerializeField]
    public Cubemap[] cubemaps;

    [Header("Stored Color Sky")]
    public Color colorSkyLight;

    [Header("Stored Light Probes Settings")]
    [SerializeField]
    public SphericalHarmonicsL2[] lightProbesData;

    [Header("Stored Volume Settings")]
    [SerializeField]
    public VolumeProfile profileVolume;



#if UNITY_EDITOR
    //The EditorWindow_GetAlternativeLightingData script uses these value to temporary store the found textures
    [HideInInspector]
    public List<Texture2D> l_LightTemp;
    [HideInInspector]
    public List<Texture2D> l_DirTemp;
#endif
}
