using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    public Light2D light2D;

    public float minIntensity, maxIntensity;

    public float valueChange;

    bool LightGrow;

    void Update()
    {
        Flicker();
    }

    void Flicker()
    {
        if (!LightGrow)
        {
            if (light2D.intensity < minIntensity)
            {
                LightGrow = true;
            }
            else
            {
                light2D.intensity -= valueChange * Time.deltaTime;
            }
        }

        if (LightGrow)
        {
            if (light2D.intensity > maxIntensity)
            {
                LightGrow = false;
            }
            else
            {
                light2D.intensity += valueChange * Time.deltaTime;
            }
        }
    }
}
