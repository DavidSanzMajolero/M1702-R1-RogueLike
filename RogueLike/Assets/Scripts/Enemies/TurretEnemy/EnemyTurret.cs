using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    /*
    public Transform player; // Referencia al jugador
    public GameObject projectilePrefab; // Prefab del proyectil
    public float shootingSpeed = 5f; // Velocidad del proyectil
    public float timeBetweenShots = 2f; // Tiempo entre disparos
    public int poolSize = 5; // Tamaño de la pool de proyectiles

    private float timeToNextShot = 0f; // Tiempo para el próximo disparo
    private Queue<GameObject> projectilePool; // Cola de proyectiles

    void Start()
    {
        // Inicializar la pool de proyectiles
        projectilePool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.SetActive(false);

            // Asignar el controlador de la pool al proyectil
            EnemyProj enemyProjectile = projectile.GetComponent<EnemyProj>();
            if (enemyProjectile != null)
            {
                enemyProjectile.SetPoolController(this);
            }

            projectilePool.Enqueue(projectile);
        }
    }

    void Update()
    {
        // Buscar al jugador si aún no está asignado
        if (player == null)
        {
            GameObject foundPlayer = GameObject.FindGameObjectWithTag("Player");
            if (foundPlayer != null)
            {
                player = foundPlayer.transform;
            }
        }

        // Disparar al jugador si es el momento
        if (Time.time > timeToNextShot && player != null)
        {
            Shoot();
            timeToNextShot = Time.time + timeBetweenShots;
        }
    }

    void Shoot()
    {
        if (player != null && projectilePool.Count > 0)
        {
            GameObject projectile = projectilePool.Dequeue();
            projectile.SetActive(true);
            projectile.transform.position = transform.position;
            projectile.transform.rotation = Quaternion.identity;

            // Calcular la dirección hacia el jugador
            Vector2 direction = (player.position - transform.position).normalized;
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * shootingSpeed;
            }
        }
    }

    public void ReturnProjectileToPool(GameObject projectile)
    {
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }

        projectile.SetActive(false);
        projectilePool.Enqueue(projectile);
    }
    */
}
