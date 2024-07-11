using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 100;

    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }
    public void TakeDamage(int damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints = hitPoints - damage;
        if(hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }
}
