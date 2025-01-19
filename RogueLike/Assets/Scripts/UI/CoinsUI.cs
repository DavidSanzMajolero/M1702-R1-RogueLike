using System;
using UnityEngine;

public class CoinsUI : MonoBehaviour
{
    private void Update()
    {
        // Cambiamos el texto del UI a la cantidad de monedas que tenemos
        GetComponent<TMPro.TextMeshProUGUI>().text = Magician.Instance.coins.ToString();
    }
}
