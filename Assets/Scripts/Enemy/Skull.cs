using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Skull : MonoBehaviour
{
    [Header("Controller")]
    public Entity entity;

    [Header("Patrol")]
    public Transform[] waypointList;
    public float arrivalDistance = 0.5f;
    public float waitTime = 5;

    //private Variables
    Transform targetWaypoint;
    int currentyWaypoint = 0;
    float lastDistanceToTarget = 0f;
    float currentyWaitTime = 0f;


    Rigidbody2D rb2D;
    Animator animator;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        entity.currentHealth = entity.maxHealth;
        //health.maxValue = entity.maxHealth;
        //health.value = health.maxValue;

        currentyWaitTime = waitTime;
        if (waypointList.Length > 0)
        {
            targetWaypoint = waypointList[currentyWaypoint];
            lastDistanceToTarget = Vector2.Distance(transform.position, targetWaypoint.position);
        }
    }
}
