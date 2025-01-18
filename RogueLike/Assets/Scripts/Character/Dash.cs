using System.Collections;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private float dashSpeed = 10f;   
    [SerializeField] private float dashDuration = 0.2f; 
    [SerializeField] private float dashCooldown = 1f;

    private bool isDashing = false;
    private bool canDash = true;    
    private Rigidbody2D rb;         
    private PlayerInputSystem playerInput;

    public bool dashBuyed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInputSystem>();
        if (rb == null || playerInput == null)
        {
            Debug.LogError("Faltan referencias al Rigidbody2D o al PlayerInputSystem.");
        }
    }

    void Update()
    {
        MagicianDash();
    }

    void MagicianDash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canDash && !isDashing && dashBuyed)
        {
            StartCoroutine(PerformDash());
        }
    }

    private IEnumerator PerformDash()
    {
        isDashing = true;
        canDash = false;

        Vector2 dashDirection = playerInput.direction.normalized; 
        if (dashDirection == Vector2.zero)
        {
            dashDirection = Vector2.right; 
        }

        float startTime = Time.time;

        while (Time.time < startTime + dashDuration)
        {
            rb.velocity = dashDirection * dashSpeed;
            yield return null;
        }

        rb.velocity = Vector2.zero; 
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
