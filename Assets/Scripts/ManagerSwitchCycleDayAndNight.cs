using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ManagerSwitchCycleDayAndNight : MonoBehaviour
{
    [SerializeField]
    LightingSceneData lightingSceneDataDay;
    [SerializeField]
    LightingSceneData lightingSceneDataNight;

    [SerializeField]
    LightmapSwitchTool lightmapSwitch; //reference to the lightmap tool that changes the lightmap
    [SerializeField]
    VolumeSwitchTool volumeSwitch;  //reference to the volume tool that changes the profile of the volume
    [SerializeField]
    LightsSwitchTool lightsSwitch;  //reference to the lights tool that changes the lights color ONLY FOR REALTIME LIGHTS

    bool changeVar = false;
    private void Start()
    {
        //lightmapSwitch.ChangeReflectionProbes(lightingSceneDataNight.cubemaps);

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!changeVar)
            {
                lightmapSwitch.ChangeLightmaps(lightingSceneDataDay.l_Dir, lightingSceneDataDay.l_Light);
                volumeSwitch.ChangeVolumeProfile(lightingSceneDataDay.profileVolume);
                lightmapSwitch.ChangeReflectionProbes(lightingSceneDataDay.cubemaps);
                //lightsSwitch.ChangeLights(lightingSceneDataDay.colorSkyLight);
            }
            else
            {
                lightmapSwitch.ChangeLightmaps(lightingSceneDataNight.l_Dir, lightingSceneDataNight.l_Light);
                volumeSwitch.ChangeVolumeProfile(lightingSceneDataNight.profileVolume);
                lightmapSwitch.ChangeReflectionProbes(lightingSceneDataNight.cubemaps);

                //lightsSwitch.ChangeLights(lightingSceneDataNight.colorSkyLight);

            }

            changeVar =!changeVar;

        }
    }
}
