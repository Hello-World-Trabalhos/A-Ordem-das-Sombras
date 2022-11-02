using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    [SerializeField] private bool isShowDraw;
    [SerializeField] private float activeTimer = 0.1f;
    [SerializeField] private Transform pointDetection;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float radius;

    private float timer;
    private bool canDamage = true;
    private Player player;
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
            player = Physics2D.OverlapCircle(pointDetection.position, radius, layerMask).GetComponent<Player>();

            if (canDamage)
            {
                player.TakeDamage(damage);
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
}
