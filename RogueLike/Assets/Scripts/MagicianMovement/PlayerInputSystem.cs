using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputSystem : MonoBehaviour, Inputs.IPlayerActions
{
    #region Variables
    private Inputs inputs;
    public Vector2 direction;
    public Vector2 speed;
    //public bool facingLeft;
    //public bool facingRight;
    #endregion

    private void Awake()
    {
        inputs = new Inputs();
        inputs.Player.SetCallbacks(this);
    }

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            direction = context.ReadValue<Vector2>();

        }
        else if (context.canceled)
        {
            direction = Vector2.zero;
        }
    }
}
