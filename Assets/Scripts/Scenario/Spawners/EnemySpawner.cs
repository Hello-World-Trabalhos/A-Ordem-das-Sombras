using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public void SpawnEnemies()
    {
        SpawnEnemies(ScenarioConstants.ENEMIES_PER_ROOM);
    }

    public void SpawnEnemies(int enemiesPerRoom)
    {
        if (enemiesPerRoom <= 0)
        {
            return;
        }

        List<GameObject> interiorRoomsToSpawnEnemies = interiorRoomStorage.GetAllSpawnedInteriorRooms().ToList();
        interiorRoomsToSpawnEnemies.Remove(interiorRoomStorage.GetBossInteriorRoom());
        interiorRoomsToSpawnEnemies.Remove(interiorRoomStorage.GetPlayerInteriorRoom());

        foreach (GameObject interiorRoom in interiorRoomsToSpawnEnemies)
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
        List<int> possibleIndex = new List<int>();

        for (int i = 0; i < enemiesSpawns.Length; i++)
        {
            possibleIndex.Add(i);
        }

        for (int i = 0; i < enemiesPerRoom; i++)
        {
            int randomIndex = Random.Range(0, possibleIndex.Count);
            choosedSpawns[i] = enemiesSpawns[possibleIndex[randomIndex]];
            possibleIndex.RemoveAt(randomIndex);
        }

        return choosedSpawns;
    }

    private GameObject GetEnemyModelToSpawn()
    {
        return enemyModels.enemyModels[Random.Range(0, enemyModels.enemyModels.Length)];
    }
}
