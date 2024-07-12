using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 70f;
    [SerializeField] float intensityAmount = 7f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            FindObjectOfType<FlashLightSystem>().RestoreLightAngle(restoreAngle);
            FindObjectOfType<FlashLightSystem>().RestoreLightIntensity(intensityAmount);
            Destroy(gameObject);
        }
    }
}
