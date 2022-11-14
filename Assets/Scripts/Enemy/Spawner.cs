using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] public Transform spawnerPrefab;

    void Start()
    {
        spawnerPrefab = GameObject.Find("Boss").transform.Find("Hit").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(float targetX, float targetY, Transform boss)
    {
        GameObject tempBall = Instantiate(prefab,spawnerPrefab.position, Quaternion.identity);

        tempBall.GetComponent<BossAttack>().Direction(targetX, targetY, boss);
        //colocar som aqui
    }

    private void Move()
    {
        //Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        //Vector2 offset = new Vector2(target.x - screenPoint.x, target.y - screenPoint.y);

        //float angle = Mathf.Atan2(offset.x, offset.y) * Mathf.Rad2Deg;

        //rotationZ = Quaternion.Euler(0, 0, angle);


        //move.x = speed * Time.deltaTime;
        //move.y = speed * Time.deltaTime;

        //transform.position += 
    }
}
