using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = 1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 20f;

    Light myFlashlight;

    private void Start()
    {
        myFlashlight = GetComponent<Light>();

    }

    private void Update()
    {
        DecreaseFlashlightAngle();
        DecreaseFlashlightIntensity();
    }

    private void DecreaseFlashlightAngle()
    {
        if(myFlashlight.spotAngle <= minimumAngle)
        {
            return;
        }
        else
        {
            myFlashlight.spotAngle -= angleDecay * Time.deltaTime;
        }
    }
    private void DecreaseFlashlightIntensity()
    {
        myFlashlight.intensity -= lightDecay * Time.deltaTime;
    }
}
