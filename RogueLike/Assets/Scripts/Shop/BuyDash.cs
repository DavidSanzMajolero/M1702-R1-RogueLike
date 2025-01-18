using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyDash : MonoBehaviour
{
    private BuyItem buyItem;
    private Dash dashComponent;

    private void Start()
    {
        buyItem = GetComponent<BuyItem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && buyItem != null && buyItem.canBuy)
        {
            dashComponent = other.GetComponent<Dash>();
            if (dashComponent != null)
            {
                ActivateDash();
            }

        }
    }

    void ActivateDash()
    {
        dashComponent.dashBuyed = true;
        Destroy(gameObject);
    }
}
