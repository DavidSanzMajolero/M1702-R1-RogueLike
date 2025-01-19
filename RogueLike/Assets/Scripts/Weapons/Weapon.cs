using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    #region Variables
    public float dammage;
    public float delay;
    public float range;
    public int cost;
    #endregion

    virtual public void Attack()
    {
        // Attack logic
    }
}
