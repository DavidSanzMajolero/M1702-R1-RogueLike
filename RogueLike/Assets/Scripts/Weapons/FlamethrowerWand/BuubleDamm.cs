using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuubleDamm : MonoBehaviour
{
    [SerializeField] private int damageAmount = 1;

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.GetComponent<EnemyController>())
        {
            EnemyController aiChase = other.gameObject.GetComponent<EnemyController>();
            Debug.Log("Enemy hit");
            aiChase.TakeDamage(damageAmount);
        }
        else if (other.gameObject.GetComponent<EnemyShooter>())
        {
            EnemyShooter enemyTurret = other.gameObject.GetComponent<EnemyShooter>();
            Debug.Log("Enemy turret hit");
            enemyTurret.TakeDamage(damageAmount);
        }
    }
}
