using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotion : MonoBehaviour
{
    private BuyItem buyItem;
    private PlayerInputSystem playerInputSystem;
    private void Start()
    {
        buyItem = GetComponent<BuyItem>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && buyItem != null && buyItem.canBuy)
        {
            playerInputSystem = other.GetComponent<PlayerInputSystem>();
            if (playerInputSystem != null)
            {
                ActivatePot();
            }
        }
    }

    void ActivatePot()
    {
        playerInputSystem.speed *= 1.3f;
        Destroy(gameObject);
    }
}
