using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 100;
    DeathHandler deathHandler;
    DisplayDamage displayDamage;

    private void Start()
    {
        deathHandler = FindObjectOfType<DeathHandler>();
        displayDamage = FindObjectOfType<DisplayDamage>();
    }
    public void TakeDamage(int damage)
    {
        hitPoints = hitPoints - damage;
        displayDamage.DisplayDamageCanvas();
        if(hitPoints <= 0)
        {
            deathHandler.HandleDeath();
            
        }
    }
}
