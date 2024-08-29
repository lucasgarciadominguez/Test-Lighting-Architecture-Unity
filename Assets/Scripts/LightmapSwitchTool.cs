using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class LightmapSwitchTool : MonoBehaviour
{
    [HideInInspector]
    public Texture2D[] l_light;
    [HideInInspector]
    public Texture2D[] l_dir;

    [SerializeField]
    private ReflectionProbe[] reflectionProbes;
    [SerializeField]
    private HDAdditionalReflectionData[] reflectionData;

    void Start()
    {
        foreach (ReflectionProbe reflectionProbe in reflectionProbes)
        { 
            reflectionProbe.mode = ReflectionProbeMode.Custom;  //makes the reflection, custom
        }
        reflectionData=new HDAdditionalReflectionData[reflectionProbes.Length];
        for (int i = 0; i < reflectionProbes.Length; i++)
        {
            reflectionData[i] = reflectionProbes[i].gameObject.GetComponent<HDAdditionalReflectionData>();
        }
    }

    public void ChangeLightmaps(Texture2D _dir, Texture2D _light)
    {
       
        LightmapSettings.lightmaps = new LightmapData[0];

        // Creates a lightmap data array
        LightmapData[] lightmaparray = new LightmapData[1]; 
        LightmapData mapdata = new LightmapData(); 

        mapdata.lightmapDir = _dir;
        mapdata.lightmapColor = _light;

        // Asign the new instance to the array
        lightmaparray[0] = mapdata;

        // Assign the lightmaps to the LightmapSettings
        LightmapSettings.lightmaps = lightmaparray;

        Debug.Log("Lightmaps updated and previous lightmaps cleared.");

    }
    public void ChangeLightmaps(Texture2D _dir, Texture2D _light, Texture2D _shadow)
    {
        // Limpiar el array de lightmaps existente
        LightmapSettings.lightmaps = new LightmapData[0];

        // Crear un nuevo array de LightmapData con el tamaño adecuado
        LightmapData[] lightmaparray = new LightmapData[1]; // Puedes ajustar el tamaño si es necesario
        LightmapData mapdata = new LightmapData(); // Crear una nueva instancia para cada lightmap

        // Asignar las texturas
        mapdata.lightmapDir = _dir;
        mapdata.lightmapColor = _light;
        mapdata.shadowMask = _shadow;

        // Asignar la nueva instancia al array
        lightmaparray[0] = mapdata;

        // Asignar el array actualizado a LightmapSettings
        LightmapSettings.lightmaps = lightmaparray;

        Debug.Log("Lightmaps updated and previous lightmaps cleared.");
    }

    public void ChangeReflectionProbes(Cubemap[] cubemaps)
    {
        // Asigna cada cubemap al Reflection Probe correspondiente
        for (int i = 0; i < reflectionProbes.Length; i++)
        {
            //reflectionProbes[i].Reset();
            //reflectionProbes[i].bakedTexture = cubemaps[i];
            //reflectionProbes[i].mode = ReflectionProbeMode.Custom;

            reflectionProbes[i].customBakedTexture = cubemaps[i];
            reflectionData[i].SetTexture(ProbeSettings.Mode.Custom, cubemaps[i]);
            reflectionData[i].mode=ProbeSettings.Mode.Custom;
            //textures[i] = reflectionProbes[i].bakedTexture;
            //reflectionProbes[i].gameObject.SetActive(false);
            Debug.Log($"{reflectionProbes[i].name} Texture: {reflectionProbes[i].customBakedTexture.name}");

        }
        // Forces the update
        DynamicGI.UpdateEnvironment();

    }
}