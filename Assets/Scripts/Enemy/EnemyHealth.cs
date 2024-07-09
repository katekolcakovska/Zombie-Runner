using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 100;

    public void TakeDamage(int damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints = hitPoints - damage;
        if(hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
