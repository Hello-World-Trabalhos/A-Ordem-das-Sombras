using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Skull : Caracter
{
    [Header("Controller")]
    public Entity entity;


    Rigidbody2D rb2D;
    Animator animator;

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
    public float timeLoader = 0.5f;

    private void Start()
    {
        SetTarget();

        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        entity.currentHealth = entity.maxHealth;

    }

    
    private void Update()
    {
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
            Attack();
            //to do attack
        }
    }

    #region New code
    private void SetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            entity.target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Move()
    {
        if (!entity.target)
            return;

        if (Distance())
        {
            transform.position = Vector2.MoveTowards(transform.position, entity.target.position, entity.speed * Time.deltaTime);

            animator.SetBool("isWalking", true);
            LocalAt();

            

            //if (timerAttackFinish < Time.deltaTime)
            //{
            //    Die();
            //}

        }
        else
        {
            animator.SetBool("isWalking", false);
            //to do attack
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

    private void LocalAt()
    {
        localScale = transform.localScale;
        localScale.x = transform.position.x > entity.target.position.x ? Mathf.Abs(localScale.x) : -Mathf.Abs(localScale.x);
        transform.localScale = localScale;
    }
    #endregion
    private void CanAttack()
    {
        detection.gameObject.SetActive(true);
        detection.ResetTimer();
    }
    private void Attack()
    {
        if ((Vector3.Distance(transform.position, entity.target.position) < startDistance))
        {
            timerAttackFinish = Time.time + waitAttackFinish;
            timerAttack = Time.time + waitAttack;

            animator.SetBool("attack", true);
            Die();
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

        entity.currentHealth -= damage;

        animator.SetBool("isWalking", false);

    }

    #region Old Code
    /*
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player" && !entity.dead)
        {
            entity.inCombat = true;
            entity.target = collider.gameObject;
            entity.target.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            entity.inCombat = false;
            if (entity.target)
            {
                entity.target.GetComponent<BoxCollider2D>().isTrigger = false;
                entity.target = null;
            }
        }
    }

    void Patrol()
    {
        if (entity.dead)
            return;

        // calcular a distance do waypoint
        float distanceToTarget = Vector2.Distance(transform.position, targetWaypoint.position);

        if (distanceToTarget <= arrivalDistance || distanceToTarget >= lastDistanceToTarget)
        {
            animator.SetBool("isWalking", false);

            if (currentWaitTime <= 0)
            {
                currentWaypoint++;

                if (currentWaypoint >= waypointList.Length)
                    currentWaypoint = 0;

                targetWaypoint = waypointList[currentWaypoint];
                lastDistanceToTarget = Vector2.Distance(transform.position, targetWaypoint.position);

                currentWaitTime = waitTime;
            }
            else
            {
                currentWaitTime -= Time.deltaTime;
            }
        }
        else
        {
            animator.SetBool("isWalking", true);
            lastDistanceToTarget = distanceToTarget;
        }

        Vector2 direction = (targetWaypoint.position - transform.position).normalized;
        animator.SetFloat("input_x", direction.x);
        animator.SetFloat("input_y", direction.y);

        rb2D.MovePosition(rb2D.position + direction * (entity.speed * Time.fixedDeltaTime));
    }
    */
    #endregion

    IEnumerator Attack1()
    {
        entity.combatCoroutine = true;

        while (true)
        {
            yield return new WaitForSeconds(entity.coolDown);

            if (entity.target != null && !entity.target.GetComponent<Player>().entity.isDead)
            {
                animator.SetBool("attack", true);

                float distance = Vector2.Distance(entity.target.transform.position, transform.position);

                if (distance <= entity.attackDistance)
                {
                    int dmg = entity.damage;
                    int targetDef = entity.defence;
                    int dmgResult = dmg - targetDef;

                    if (dmgResult < 0)
                        dmgResult = 0;

                    // subtraindo a vida do player
                    entity.target.GetComponent<Player>().entity.currentHealth -= dmgResult;
                }
            }
        }
    }

    public override void Died()
    {
        entity.isDead = true;
        entity.target = null;

        animator.SetBool("isWalking", false);
        Invoke("DestroyEnemy", timeLoader);
    }
}
