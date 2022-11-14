using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] public Transform spawnerPrefab;

    void Start()
    {
        spawnerPrefab = GameObject.FindGameObjectWithTag("Boss").transform.Find("Hit").transform;
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

}
