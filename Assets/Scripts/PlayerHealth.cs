using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 100;
    DeathHandler deathHandler;

    private void Start()
    {
        deathHandler = FindObjectOfType<DeathHandler>();
    }
    public void TakeDamage(int damage)
    {
        hitPoints = hitPoints - damage;
        if(hitPoints <= 0)
        {
            deathHandler.HandleDeath();
            
        }
    }
}
