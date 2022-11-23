using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class Skeleton : Caracter
{
    [Header("Controller")]
    public Entity entity = new Entity();
    //[SerializeField] public Slider hpSliper;

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
    private float timerAttack;
    private float timerAttackFinish;

    [Header("Die")]
    public float timeLoader = 1.5f;

    private void Start()
    {
        SetTarget();

        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        entity.currentHealth = entity.maxHealth;

        //hpSliper.maxValue = entity.maxHealth;
        //hpSliper.value = hpSliper.maxValue;

    }

    private void Update()
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
            Move();
        }
        else
        {
            animator.SetBool("isWalking", false);
            FinishAttack();
            Attack();
            //to do attack
        }
    }

    private void SetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            entity.target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Move()
    {
    transform.position = Vector2.MoveTowards(transform.position, entity.target.position, entity.speed * Time.deltaTime);

    animator.SetBool("isWalking", true);
    LocalAt();
    }

    private bool Distance()
    {
        if ((Vector3.Distance(transform.position, entity.target.position) > stopDistance) && Vector3.Distance(transform.position, entity.target.position) < startDistance)
        {
            return true;
        }
        return false;
    }

    private void LocalAt()
    {
        localScale = transform.localScale;
        localScale.x = transform.position.x > entity.target.position.x ? Mathf.Abs(localScale.x): -Mathf.Abs(localScale.x);
        transform.localScale = localScale;
    }

    private void CanAttack() 
    {
        detection.gameObject.SetActive(true);
        detection.ResetTimer();
    }

    private void Attack()
    {
        if((Vector3.Distance(transform.position, entity.target.position) < startDistance))
        {
            timerAttackFinish = Time.time + waitAttackFinish;
            timerAttack = Time.time + waitAttack;
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
    public void Die()
    {
        entity.isDead = true;
        entity.inCombat = false;
        entity.target = null;

        animator.SetBool("isWalking", false);
        Invoke("DestroyEnemy", timeLoader);
        // add exp no player
        //Player player = GameObject.FindGameObjectsWithTag("Player").GetComponent<Player>();
        //manager.GainExp(rewardExperience);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        if (entity.currentHealth <= 0)
            return;

        //entity.currentHealth -= damage;
        //hpSliper.value -= damage;

        animator.SetBool("isWalking", false);

    }

    public override void Died()
    {
        entity.isDead = true;
        entity.target = null;
        entity.currentHealth = 0;

        animator.SetBool("isWalking", false);
        Invoke("DestroyEnemy", timeLoader);
    }
}
