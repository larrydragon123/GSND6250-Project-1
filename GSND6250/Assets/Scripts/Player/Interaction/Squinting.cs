using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Squinting : MonoBehaviour
{
    public Volume volume;
    public bool isfixed = false;


    // Start is called before the first frame update
    void Start()
    {
        isfixed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //when mouse right click is held down
        if (Input.GetMouseButton(1))
        {
            volume.profile.TryGet(out Vignette vignette);
            vignette.intensity.value = 0.75f;
            volume.profile.TryGet(out DepthOfField DOF);
            if(isfixed)
                DOF.SetAllOverridesTo(false);
            else
                DOF.focusDistance.value = 1.5f;
            
        }
        else
        {
            volume.profile.TryGet(out Vignette vignette);
            vignette.intensity.value = 0f;
            volume.profile.TryGet(out DepthOfField DOF);
            if(isfixed)
                DOF.SetAllOverridesTo(false);
            else
                DOF.focusDistance.value = 1;
        }
    }
}
