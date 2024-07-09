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
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 0.5f;
    

    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetAmmo(ammoType) > 0)
        {
            ammoSlot.ReduceAmmo(ammoType);
            PlayMuzzleFlash();
            ProcessRaycast();
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;

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
