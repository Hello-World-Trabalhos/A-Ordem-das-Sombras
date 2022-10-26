using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class Skeleton : MonoBehaviour
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
    private float timerAttack;
    private float timerAttackFinish;
    private void Start()
    {
        SetTarget();

        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        entity.currentHealth = entity.maxHealth;

    }

    private void Update()
    {
        //old code
        if (entity.dead)
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
    //OLD CODE
    #region old code
    /*
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player" && !entity.dead)
        {
            entity.inCombat = true;
            //entity.target = collider.gameObject;
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
        //float distanceToTarget = Vector2.Distance(transform.position, targetWaypoint.position);

        //if (distanceToTarget <= arrivalDistance || distanceToTarget >= lastDistanceToTarget)
        //{
        //    animator.SetBool("isWalking", false);

        //    //faz a movimentação do player
        //    if (currentWaitTime <= 0)
        //    {
        //        currentWaypoint++;

        //        if (currentWaypoint >= waypointList.Length)
        //            currentWaypoint = 0;

        //        targetWaypoint = waypointList[currentWaypoint];
        //        lastDistanceToTarget = Vector2.Distance(transform.position, targetWaypoint.position);

        //        currentWaitTime = waitTime;
        //    }
        //    else
        //    {
        //        currentWaitTime -= Time.deltaTime;
        //    }
        //}
        //else
        //{
        //    animator.SetBool("isWalking", true);
        //    lastDistanceToTarget = distanceToTarget;
        //}

        //Vector2 direction = (targetWaypoint.position - transform.position).normalized;
        //animator.SetFloat("input_x", direction.x);
        //animator.SetFloat("input_y", direction.y);

        //rb2D.MovePosition(rb2D.position + direction * (entity.speed * Time.fixedDeltaTime));
    }
    */
    #endregion

    private void Attack()
    {
        timerAttackFinish = Time.time + waitAttackFinish;
        timerAttack = Time.time + waitAttack;
        animator.SetBool("attack", true);

    }

    private void FinishAttack()
    {
        if (Time.time > timerAttackFinish)
        {
            animator.SetBool("attack", false);
        }
    }
    void Die()
    {
        entity.dead = true;
        entity.inCombat = false;
        entity.target = null;

        animator.SetBool("isWalking", false);

        // add exp no player
        //Player player = GameObject.FindGameObjectsWithTag("Player").GetComponent<Player>();
        //manager.GainExp(rewardExperience);

        StopAllCoroutines();
    }

    IEnumerator Attack1()
    {
        entity.combatCoroutine = true;

        while (true)
        {
            yield return new WaitForSeconds(entity.coolDown);

            if (entity.target != null && !entity.target.GetComponent<Player>().entity.dead)
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
}
