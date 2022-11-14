using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Caracter
{
    [Header("Controller")]
    public Entity entity = new Entity();

    Rigidbody2D rb2D;
    Animator animator;

    //new code
    [Header("Patrol")]
    [SerializeField] private float stopDistance;
    [SerializeField] private float startDistance;
    private Vector3 localScale;

    [Header("Attack")]
    [SerializeField] private Detection detection;
    [SerializeField] private float waitAttack = 0.5f;
    [SerializeField] private float waitAttackFinish = 0.5f;
    [SerializeField] private Spawner spawner;
    private float timerAttack;
    private float timerAttackFinish;
    [SerializeField] public float shootTimer = 0.5f;
    private float nextShootTimer;
    //private GameObject spawnerPrefab;


    [Header("Die")]
    public float timeLoader = 1.5f;
    private EndGameManager gameManager;

    void Start()
    {
        SetTarget();
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        gameManager = GameObject.Find("EndGameManager").GetComponent<EndGameManager>();

        //spawnerPrefab = GameObject.Find("Boss").transform.Find("Hit").gameObject;

    }

    void Update()
    {
        //old code
        if (entity.isDead)
        {
            return;
        }

        if (entity.currentHealth <= 0)
        {
            entity.currentHealth = 0;
            Die();
        }

        //new code
        if (!entity.target)
            return;

        if (Distance())
        {
            //animator.SetBool("attack", true);
            FinishAttack();
            Attack();
        }
    }

    private void SetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            entity.target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private bool Distance()
    {
        if ((Vector3.Distance(transform.position, entity.target.position) > stopDistance) && Vector3.Distance(transform.position, entity.target.position) < startDistance)
        {
            return true;
        }
        return false;
    }


    private void Shoot()
    {
        nextShootTimer = Time.time + shootTimer;
        spawner.Shoot(entity.target.position.x, entity.target.position.y,transform);
    }

    private void HandleShoot()
    {
        if (Time.time > nextShootTimer)
        {
            Shoot();
        }
    }
    private void Attack()
    {
        if ((Vector3.Distance(transform.position, entity.target.position) < startDistance))
        {
            timerAttackFinish = Time.time + waitAttackFinish;
            timerAttack = Time.time + waitAttack;
            HandleShoot();
            animator.SetBool("attack", true);
        }

    }

    private void FinishAttack()
    {
        if (Time.time > timerAttackFinish)
        {
            animator.SetBool("attack", false);
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    public override void Died()
    {
        entity.isDead = true;
        entity.target = null;

        animator.SetBool("isWalking", false);
        gameManager.ShowEndGamePanel(EndGameOption.BOSS_KILLED);
        Invoke("DestroyEnemy", timeLoader);

    }

    public void Die()
    {
        entity.isDead = true;
        entity.inCombat = false;
        entity.target = null;

        animator.SetBool("isWalking", false);
        SceneLoader.LoadMainMenu();
        Invoke("DestroyEnemy", timeLoader);
        // add exp no player
        //Player player = GameObject.FindGameObjectsWithTag("Player").GetComponent<Player>();
        //manager.GainExp(rewardExperience);
    }
}
