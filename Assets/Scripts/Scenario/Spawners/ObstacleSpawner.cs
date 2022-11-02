using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private ObstacleModels obstacleModelsReference;

    void Start()
    {
        obstacleModelsReference = GameObject.Find("ObstacleModels").GetComponent<ObstacleModels>();
    }

    public void SpawnObstacles()
    {
        int maxObstacleModelsIndex = obstacleModelsReference.obstacleModels.Length;
        GameObject[] obstacleSpawnPoints = GameObject.FindGameObjectsWithTag("ObstacleSpawn");

        foreach (GameObject spawnPoint in obstacleSpawnPoints)
        {
            int randomIndex = Random.Range(0, maxObstacleModelsIndex);
            GameObject obstacleToInstantiate = obstacleModelsReference.obstacleModels[randomIndex];

            Vector3 spawnPointPosition = spawnPoint.transform.position;
            Vector3 positionToSpawn = new Vector3(spawnPointPosition.x, spawnPointPosition.y, 0);

            Instantiate(obstacleToInstantiate, positionToSpawn, Quaternion.identity);
        }
    }
}
