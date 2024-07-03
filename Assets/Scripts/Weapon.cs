using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera firstPersonCamera;
    [SerializeField] int range = 100;
    [SerializeField] int damage = 30;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
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
            CreateHitImpact(hit);
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

    void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }
    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
}
