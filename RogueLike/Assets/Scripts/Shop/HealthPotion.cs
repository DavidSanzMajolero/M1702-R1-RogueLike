using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    private BuyItem buyItem;
    private void Start()
    {
        buyItem = GetComponent<BuyItem>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && buyItem.canBuy)
        {
            Magician playerHealth = other.GetComponent<Magician>();
            if (playerHealth != null)
            {
                ActivatePotion(playerHealth);
            }
        }
    }

    void ActivatePotion(Magician playerHealth)
    {
        playerHealth.MaxHealth += 5;
        playerHealth.Health = playerHealth.MaxHealth;
        Destroy(gameObject);
    }
}
