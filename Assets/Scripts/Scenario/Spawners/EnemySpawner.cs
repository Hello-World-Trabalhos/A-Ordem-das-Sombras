using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private EnemyModels enemyModels;
    private InteriorRoomStorage interiorRoomStorage;

    void Start()
    {
        enemyModels = GameObject.Find("EnemyModels").GetComponent<EnemyModels>();
        interiorRoomStorage = GameObject.Find("InteriorRoomStorage").GetComponent<InteriorRoomStorage>();
    }

    public void SpawnEmemies()
    {
        SpawnEnemies(ScenarioConstants.ENEMIES_PER_ROOM);
    }

    public void SpawnEnemies(int enemiesPerRoom)
    {
        foreach (var interiorRoom in interiorRoomStorage.GetAllSpawnedInteriorRooms())
        {
            GameObject[] enemiesSpawns = GetEnemySpawnsFromInteriorRoom(interiorRoom);
            GameObject[] choosedEnemiesSpawns = ChooseEnemiesSpawnPoints(enemiesSpawns, enemiesPerRoom);

            foreach (GameObject choosedEnemySpawn in choosedEnemiesSpawns)
            {
                Vector3 choosedEnemySpawnPosition = choosedEnemySpawn.transform.position;
                Vector3 positionToSpawn = new Vector3(choosedEnemySpawnPosition.x, choosedEnemySpawnPosition.y, 0);
                GameObject enemyModel = GetEnemyModelToSpawn();

                Instantiate(enemyModel, positionToSpawn, Quaternion.identity);
            }
        }
    }

    private GameObject[] GetEnemySpawnsFromInteriorRoom(GameObject interiorRoom)
    {
        GameObject enemiesSpawnsGameObject = interiorRoom.transform.Find("EnemiesSpawns").gameObject;
        int ammountEnemiesSpawns = enemiesSpawnsGameObject.transform.childCount;
        GameObject[] enemiesSpawns = new GameObject[ammountEnemiesSpawns];

        for (int i = 0; i < ammountEnemiesSpawns; i++)
        {
            enemiesSpawns[i] = enemiesSpawnsGameObject.transform.GetChild(i).gameObject;
        }

        return enemiesSpawns;
    }

    private GameObject[] ChooseEnemiesSpawnPoints(GameObject[] enemiesSpawns, int enemiesPerRoom)
    {
        GameObject[] choosedSpawns = new GameObject[enemiesPerRoom];
        List<int> possibleIndexex = new List<int>();

        for (int i = 0; i < enemiesPerRoom; i++)
        {
            possibleIndexex.Add(i);
        }

        for (int i = 0; i < enemiesPerRoom; i++)
        {
            int randomIndex = Random.Range(0, possibleIndexex.Count);
            choosedSpawns[i] = enemiesSpawns[randomIndex];
            possibleIndexex.Remove(randomIndex);
        }

        return choosedSpawns;
    }

    private GameObject GetEnemyModelToSpawn()
    {
        return enemyModels.enemyModels[Random.Range(0, enemyModels.enemyModels.Length)];
    }
}
