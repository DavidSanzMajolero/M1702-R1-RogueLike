using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* IMPORTATE
 * 
 * 
 * 
 * 
 * AL HACERLO PREFAB SE ROMPE Y NO DISPARA AL JUGADOR, SI SE HACE INSTANCIADO EN LA ESCENA FUNCIONA CORRECTAMENTE
 */
public class EnemyShooter : MonoBehaviour
{
    public Transform player;
    public GameObject projectilePrefab;
    public float shootingSpeed = 5f;
    public float timeBetweenShots = 2f;
    public int poolSize = 5;

    private float timeToNextShot = 0f;
    private Queue<GameObject> projectilePool;

    public float HP;
    public float maxHP = 10;

    public float knockbackForce = 5f;

    [SerializeField] private GameObject deathFVX;
    [SerializeField] private Material flashMaterial;

    private Material material;
    private SpriteRenderer spriteRenderer;
    private bool coroutineFinished = true;
    private bool isShooting = false;

    private KnockBack knockBack;
    private Animator animator;

    [SerializeField] FloatingHealthBar healthBar;
    private bool showBar;

    public bool notInRoom = false;

    [SerializeField] private GameObject coinCoinPrefab;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        material = spriteRenderer.material;
        knockBack = GetComponent<KnockBack>();
        animator = GetComponent<Animator>();
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        HP = maxHP;
        ShouldShowBar();
        projectilePool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.SetActive(false);

            EnemyProj enemyProjectile = projectile.GetComponent<EnemyProj>();
            if (enemyProjectile != null)
            {
                enemyProjectile.SetPoolController(this);
            }

            projectilePool.Enqueue(projectile);
        }
    }

    void Update()
    {
        if (player == null)
        {
            GameObject foundPlayer = GameObject.FindGameObjectWithTag("Player");
            if (foundPlayer != null)
            {
                player = foundPlayer.transform;
            }
        }

        if (player != null)
        {
            Vector3 scale = transform.localScale;
            if (player.position.x < transform.position.x && scale.x > 0)
            {
                scale.x = -Mathf.Abs(scale.x);
            }
            else if (player.position.x > transform.position.x && scale.x < 0)
            {
                scale.x = Mathf.Abs(scale.x);
            }
            transform.localScale = scale;
        }

        if (Time.time > timeToNextShot && player != null)
        {
            Shoot();
            timeToNextShot = Time.time + timeBetweenShots;
        }
    }

    void Shoot()
    {
        if (notInRoom == true)
        {
            if (player != null && projectilePool.Count > 0)
            {
                GameObject projectile = projectilePool.Dequeue();
                projectile.SetActive(true);
                projectile.transform.position = transform.position;
                projectile.transform.rotation = Quaternion.identity;

                Vector2 targetPosition = player.position;
                Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = direction * shootingSpeed;
                }
            }
        }
    }

    public void ReturnProjectileToPool(GameObject projectile)
    {
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }

        projectile.SetActive(false);
        projectilePool.Enqueue(projectile);
    }

    private bool RandomBool()
    {
        return Random.value > 0.5f;
    }

    private void Awake()
    {
        showBar = RandomBool();
    }

    private void ShouldShowBar()
    {
        if (showBar) healthBar.UpdateHealthBar(HP, maxHP);
        else healthBar.gameObject.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        if (coroutineFinished)
        {
            StartCoroutine(DamageAnimation());
            HP -= damage;
            healthBar.UpdateHealthBar(HP, maxHP);
            knockBack.GetKnockedBack(knockBack.transform, knockbackForce);
            CheckIfAlive();
        }
    }

    void CheckIfAlive()
    {
        if (HP <= 0)
        {
            Instantiate(coinCoinPrefab, transform.position, Quaternion.identity);
            RoomController.instance.StartCoroutine(RoomController.instance.RoomCoroutine());
            Instantiate(deathFVX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    IEnumerator DamageAnimation()
    {
        coroutineFinished = false;
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.material = material;
        coroutineFinished = true;
    }
}
