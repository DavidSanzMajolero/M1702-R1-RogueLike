using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    // si el jugador entra en el trigel del objeto , se le restan las monedas
    public int price;
    public bool canBuy = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Magician.Instance.coins >= price)
        {
            if(price <= Magician.Instance.coins)
            {
                Magician.Instance.coins -= price;
                canBuy = true;
            }
        }
    }
}
