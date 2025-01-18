using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Magician : Character
{
    public static Magician Instance;
    [SerializeField] private Transform weaponCollider;
    private Material material;
    [SerializeField] private Material flashMaterial;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject deathFVX;
    public PlayerInputSystem playerInputSystem;
    public ActiveWeapon activeWeapon;

    public int coins;

    void Awake()
    {
        Instance = this;
        material = GetComponent<SpriteRenderer>().material;
        spriteRenderer = GetComponent<SpriteRenderer>();
        material = spriteRenderer.material;
    }

    public override void Attack() {}

    public override void TakeDammage(float damage)
    {
        Health -= damage;
        //Debug.Log("Magician took damage: " + damage + ". Current health: " + Health);

        if (Health <= 0)
        {
            Instantiate(deathFVX, transform.position, Quaternion.identity);
            spriteRenderer.enabled = false;
            playerInputSystem.enabled = false;
            activeWeapon.gameObject.SetActive(false);
            SceneManager.LoadScene("PlayerDeath");
        }
        else if (Health <= MaxHealth)
        {
            StartCoroutine(DamageAnimation());
        }
    }
    IEnumerator DamageAnimation()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.material = material;
    }
    public Transform GetWeaponCollider()
    {
        return weaponCollider;
    }

    public void SumCoin(int coin)
    {
        coins += coin;
    }   
}
