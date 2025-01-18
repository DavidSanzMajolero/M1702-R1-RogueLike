using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    #region Variables
    public float Health;
    public float MaxHealth;
    public float DammageBase;
    //public float Speed;
    #endregion

    #region Methods
    abstract public void Attack();
    //abstract public void Move(Vector2 direction);
    abstract public void TakeDammage(float dammage);
    #endregion

}
