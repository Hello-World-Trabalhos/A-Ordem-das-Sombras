using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Entity
{
    [Header("Name")]

    public string name;
    public int level = 1;

    [Header("Health")]
    public int currentHealth;
    public int maxHealth;

    [Header("Experience")]
    public int currentXP;
    public int maxXP;

    [Header("Stats")]
    public int strength = 1;
    public int resistence;
    public int damage;
    public int defence;
    public float speed = 2.5f;

    [Header("Combat")]
    public float attackDistance = 0.5f;
    public float attackTimer = 1f;
    public float coolDown = 2f;
    public bool inCombat = false;
    public GameObject target;
    public bool combatCoroutine = false;
    public bool dead = false;

    [Header("Component")]
    public AudioSource entityAudio;
}