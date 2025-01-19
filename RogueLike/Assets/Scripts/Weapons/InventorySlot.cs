using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private WeaponInfo weaponInfo;
    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
}
