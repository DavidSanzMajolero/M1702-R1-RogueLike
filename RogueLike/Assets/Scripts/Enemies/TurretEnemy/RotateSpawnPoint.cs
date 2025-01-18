using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpawnPoint : MonoBehaviour
{
    public Transform player;  // Referencia al transform del jugador
    public Transform enemy;   // Referencia al transform del enemigo (padre del spawnpoint)
    public float orbitSpeed = 5f;  // Velocidad de rotación alrededor del enemigo
    public float orbitRadius = 1.5f; // Radio de órbita del spawnpoint

    void Update()
    {
        if (player != null && enemy != null)
        {
            // Calcula la dirección hacia el jugador
            Vector2 direction = player.position - enemy.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            // Calcula la nueva posición del spawnpoint en órbita alrededor del enemigo
            Vector3 orbitPosition = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0) * orbitRadius;

            // Aplica la posición calculada al spawnpoint
            transform.position = enemy.position + orbitPosition;

            // Asegura que el spawnpoint esté siempre mirando hacia el jugador
            transform.up = direction;
        }
    }
}
