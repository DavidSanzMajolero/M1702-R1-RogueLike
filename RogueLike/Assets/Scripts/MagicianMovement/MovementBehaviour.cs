using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    #region Variables
    PlayerInputSystem playerInputSystem;
    private Rigidbody2D rb;
    private Animator animator;
    private float moveX;
    private float moveY;
    #endregion

    private void Awake()
    {
        playerInputSystem = GetComponent<PlayerInputSystem>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Vector2 direction = playerInputSystem.direction;

        moveX = direction.x;
        moveY = direction.y;

        animator.SetFloat("Horizontal", moveX);
        animator.SetFloat("Vertical", moveY);
        float speed = direction.sqrMagnitude;
        animator.SetFloat("Speed", speed);

        Move(playerInputSystem.direction);
    }
    private void Move(Vector2 direction)
    {
        rb.velocity = direction * playerInputSystem.speed;
    }

}
