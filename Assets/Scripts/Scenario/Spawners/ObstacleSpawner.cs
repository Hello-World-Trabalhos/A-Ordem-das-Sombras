using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private ObstacleModels obstacleModelsReference;
    private InteriorRoomStorage interiorRoomsStorage;

    void Start()
    {
        obstacleModelsReference = GameObject.Find("ObstacleModels").GetComponent<ObstacleModels>();
        interiorRoomsStorage = GameObject.Find("InteriorRoomStorage").GetComponent<InteriorRoomStorage>();
    }

    public void SpawnObstacles()
    {
        int maxObstacleModelsIndex = obstacleModelsReference.obstacleModels.Length;
        GameObject[] obstacleSpawnPoints = GameObject.FindGameObjectsWithTag("ObstacleSpawn");

        foreach (GameObject spawnPoint in obstacleSpawnPoints)
        {
            int randomIndex = Random.Range(0, maxObstacleModelsIndex);
            GameObject obstacleToInstantiate = obstacleModelsReference.obstacleModels[randomIndex];

            Instantiate(obstacleToInstantiate, spawnPoint.transform.position, Quaternion.identity);
        }
    }
}