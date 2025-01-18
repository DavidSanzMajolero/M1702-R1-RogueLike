using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeField] private int damageAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<EnemyController>())
        {
            EnemyController aiChase = other.gameObject.GetComponent<EnemyController>();
            aiChase.TakeDamage(damageAmount);
        }
        else if (other.gameObject.GetComponent<EnemyShooter>())
        {
            EnemyShooter enemyTurret = other.gameObject.GetComponent<EnemyShooter>();
            enemyTurret.TakeDamage(damageAmount);

        }
    }
}

