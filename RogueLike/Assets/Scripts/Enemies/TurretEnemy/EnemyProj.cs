using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase del proyectil
public class EnemyProj : MonoBehaviour
{
    public int damage = 2;
    private EnemyShooter poolController;
    public GameObject particleOnHitPrefabVFX;

    public void SetPoolController(EnemyShooter controller)
    {
        poolController = controller;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Magician playerHealth = collision.GetComponent<Magician>();
            if (playerHealth != null)
            {
                playerHealth.TakeDammage(damage);
                poolController.ReturnProjectileToPool(gameObject);
                Instantiate(particleOnHitPrefabVFX, transform.position, transform.rotation);

            }
        }
        if (collision.GetComponent<Indestructible>() != null)
        {
            poolController.ReturnProjectileToPool(gameObject);
            Instantiate(particleOnHitPrefabVFX, transform.position, transform.rotation);

        }
    }
}
