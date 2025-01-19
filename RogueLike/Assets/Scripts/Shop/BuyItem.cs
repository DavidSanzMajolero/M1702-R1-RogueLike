using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    public int price;
    public bool canBuy = false;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Magician.Instance.coins >= price)
        {
            if(price <= Magician.Instance.coins)
            {
                audioSource.Play();
                Magician.Instance.coins -= price;
                canBuy = true;
            }
        }
    }
}
