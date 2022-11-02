using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionEnemy : MonoBehaviour
{
    [SerializeField] private bool isShowDraw;
    [SerializeField] private float activeTimer = 0.1f;
    [SerializeField] private Transform pointDetection;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float radius;

    private HealthEnemy healthEnemy;

    private float timer;
    private bool canDamage = true;
    //private Skeleton skeleton;
    public int damage = 10;

    void Awake()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        CheckDetection();
        ActiveAttack();
    }

    private void ActiveAttack()
    {
        if (Time.time > timer)
        {
            gameObject.SetActive(false);
        }
    }

    public void ResetTimer()
    {
        canDamage = true;
        timer = Time.time + activeTimer;
    }

    private void CheckDetection()
    {
        if(Physics2D.OverlapCircle(pointDetection.position, radius, layerMask))
        {
            healthEnemy = Physics2D.OverlapCircle(pointDetection.position, radius, layerMask).GetComponent<HealthEnemy>();
            if (healthEnemy == null)
                return;

            if (canDamage)
            {
                healthEnemy.TakeDamage(damage);
                canDamage = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (isShowDraw)
        {
            if (pointDetection != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(pointDetection.position, radius);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        healthEnemy = Physics2D.OverlapCircle(pointDetection.position, radius, layerMask).GetComponent<HealthEnemy>();

        healthEnemy.TakeDamage(damage);
        //canDamage = false;
    }
}
