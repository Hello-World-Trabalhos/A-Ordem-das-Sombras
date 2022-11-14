using UnityEngine;

public class BossAttack : MonoBehaviour
{

    [SerializeField] private float speed = 2f;
    [SerializeField] private int damage = 10;
    [SerializeField] private float livingTimer = 5f;

    private Vector3 target = Vector3.zero;
    private Vector3 boss = Vector3.zero;
    private Vector3 move = Vector3.zero;
    void Start()
    {
        Destroy(gameObject, livingTimer);
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 bossPoint = new Vector3(boss.x, boss.y, 0);

        Vector2 offset = new Vector2(target.x - bossPoint.x, target.y - bossPoint.y);

        move.x = offset.x * speed * Time.deltaTime;
        move.y = offset.y * speed * Time.deltaTime;

        transform.position += move;
    }

    public void Direction(float targetX, float targetY, Transform bossPosition)
    {
        target.x = targetX;
        target.y = targetY;
        boss = bossPosition.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //tirar vida health
            collision.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("ObstacleObject"))
        {
            Destroy(gameObject);
        }
    }
}
