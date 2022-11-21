using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDamage : MonoBehaviour
{
    [Header("Attack")]
    [SerializeField] private Detection detection;
    [SerializeField] private float waitAttackTimer = 1.5f;
    private float timerNextAttack;
    void Start()
    {
        timerNextAttack = Time.time + waitAttackTimer;
    }
    void Update()
    {
        if (Time.time > timerNextAttack)
        {
            CanAttack();
            timerNextAttack += waitAttackTimer;
        }
    }
    private void CanAttack()
    {

        detection.gameObject.SetActive(true);
        detection.ResetTimer();
    }
}
