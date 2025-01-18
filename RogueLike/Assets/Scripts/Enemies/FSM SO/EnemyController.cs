using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public StatesSO CurrentState;
    public int HP;
    public int maxHP = 15;
    public GameObject target;

    public bool explosion = false;
    private Animator animator;
    [SerializeField] private GameObject explosionRange;
    private bool coroutineFinished = true;

    private KnockBack knockBack;
    private bool hasExploded = false;

    [SerializeField] private GameObject deathFVX;

    private Material material;
    [SerializeField] private Material flashMaterial;
    private SpriteRenderer spriteRenderer;
    private bool showBar;
    [SerializeField] FloatingHealthBar healthBar;

    public bool notInRoom = false;

    [SerializeField] private GameObject coinCoinPrefab;

    private void Awake()
    {
        showBar = RandomBool();
    }
    void Start()
    {

        animator = GetComponent<Animator>();
        explosionRange.SetActive(false);
        knockBack = GetComponent<KnockBack>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        material = spriteRenderer.material;
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        HP = maxHP;
        ShouldShowBar();

    }

    private bool RandomBool()
    {
        return Random.value > 0.5f;
    }
    private void ShouldShowBar()
    {
        if (showBar) healthBar.UpdateHealthBar(HP, maxHP);

        else healthBar.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            target = collision.gameObject;
            GoToState<ChaseState>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6) GoToState<IdleState>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            GoToState<AttackState>();

            // Apply damage to the Magician if it's the target
            if (collision.gameObject.CompareTag("Player") && !hasExploded)
            {
                Magician.Instance.TakeDammage(1f);  // You can set a custom damage value
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) GoToState<IdleState>();
    }

    public void CheckIfAlife()
    {
        if (HP < 1)
        {
            DropItems();
            RoomController.instance.StartCoroutine(RoomController.instance.RoomCoroutine());
            Instantiate(deathFVX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
    public void DropItems()
    {
        Instantiate(coinCoinPrefab, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        animator.SetBool("explosion", explosion);
        CurrentState.OnStateUpdate(this);

        if (explosion)
        {
            GetComponent<ChaseBehaviour>().StopChasing();
        }
    }

    public void GoToState<T>() where T : StatesSO
    {
        if (CurrentState.StatesToGo.Find(state => state is T))
        {
            CurrentState.OnStateExit(this);
            CurrentState = CurrentState.StatesToGo.Find(obj => obj is T);
            CurrentState.OnStateEnter(this);
        }
    }

    public void TakeDamage(int damage) 
    {
        if (coroutineFinished)
        {
            StartCoroutine(DamageAnimation());
            Debug.Log(HP);
            HP -= damage;
            if (showBar) healthBar.UpdateHealthBar(HP, maxHP);
            GoToState<KnockState>();
            CheckIfAlife();
        }
    }
    public void CheckIfRun()
    {
        if (HP < 5)
        {
            GoToState<RunState>();
        }
        else
            GoToState<ChaseState>();
    }



    IEnumerator DamageAnimation()
    {
        coroutineFinished = false;
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.material = material;
        coroutineFinished = true;
        CheckIfRun();
    }

    public void Explosion()
    {
        hasExploded = true;
        explosionRange.SetActive(true);
    }

    public void StopExplosion()
    {
        explosionRange.SetActive(false);
    }
}
