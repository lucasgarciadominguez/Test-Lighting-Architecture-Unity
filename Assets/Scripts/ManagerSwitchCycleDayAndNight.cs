using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using Michsky.MUIP;
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

    [SerializeField]
    SwitchManager buttonLight;

    bool changeVar = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))    //simple but effective method for input
        {
            if (changeVar)
            {
                lightmapSwitch.ChangeLightmaps(lightingSceneDataDay.l_Dir, lightingSceneDataDay.l_Light);   //uses new lightmaps textures
                volumeSwitch.ChangeVolumeProfile(lightingSceneDataDay.profileVolume);   //sets new profile volume
                lightmapSwitch.ChangeReflectionProbes(lightingSceneDataDay.cubemaps);   //sets new reflection probes cubemaps (textures)
                buttonLight.AnimateSwitch();    //animates the UI
            }
            else
            {
                lightmapSwitch.ChangeLightmaps(lightingSceneDataNight.l_Dir, lightingSceneDataNight.l_Light);
                volumeSwitch.ChangeVolumeProfile(lightingSceneDataNight.profileVolume);
                lightmapSwitch.ChangeReflectionProbes(lightingSceneDataNight.cubemaps);
                buttonLight.AnimateSwitch();
            }

            changeVar =!changeVar;

        }
    }
}
