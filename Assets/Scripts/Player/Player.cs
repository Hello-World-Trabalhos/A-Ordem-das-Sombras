using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public Entity entity;

    [Header("Player UI")]

    public Slider health;
    public Slider experience;

    [Header("Exp")]
    public int exp;
    public int expBase;
    public int expLeft;
    public float expMod;
    public GameObject levelUpFx;
    public AudioClip levelUpSound;

    void Start()
    {
        entity.currentHealth = entity.maxHealth;
        health.maxValue = entity.maxHealth;
        health.value = health.maxValue;

        entity.currentXP = 1;
        experience.maxValue = entity.maxXP;
        experience.value = 1 ;
    }

    private void Update()
    {
        health.value = entity.currentHealth;

        if (Input.GetKeyDown(KeyCode.Space))
            entity.currentHealth -= 10;
    }
}
