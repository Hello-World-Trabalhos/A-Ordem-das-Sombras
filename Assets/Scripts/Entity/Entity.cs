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
    public int resistence = 1;
    public int damage = 1;
    public int defence = 1;
    public float speed = 2.5f;

    [Header("Combat")]
    public float attackDistance = 0.5f;
    public float attackTime = 1f;
    public float coolDown = 2f;
    public bool inCombat = false;
    public GameObject target;
    public bool combatCoroutine = false;
    public bool dead = false;
}
