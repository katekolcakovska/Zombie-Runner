using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera firstPersonCamera;
    [SerializeField] int range = 100;
    [SerializeField] int damage = 30;
    [SerializeField] ParticleSystem muzzleFlash;
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        PlayMuzzleFlash();
        ProcessRaycast();
        
    }

    void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(firstPersonCamera.transform.position, firstPersonCamera.transform.forward, out hit, range))
        {
            Debug.Log("We hit: " + hit.transform.name);
            //TODO: add some hit effect for visual feedback
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return; // ako nema enemy health pr ako pukneme vo wall ili house
            //call a method on EnemyHealth that decreases the Enemy Health
            target.TakeDamage(damage);
        }
        else
        {
            return;
            //this fixes null reference error
        }
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
}
