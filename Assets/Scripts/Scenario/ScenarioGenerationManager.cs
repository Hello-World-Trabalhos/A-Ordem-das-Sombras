using System;
using System.Collections;
using UnityEngine;

public class ScenarioGenerationManager : MonoBehaviour
{

    private RoomsStorage roomsStorage;
    private InteriorRoomSpawner interiorRoomSpawner;
    private InteriorRoomStorage interiorRoomStorage;
    private ObstacleSpawner obstacleSpawner;
    private EnemySpawner enemySpawner;

    private TimeUtils timeUtils = new TimeUtils();
    private float timeToWaitRoomsSpawn;

    void Start()
    {
        ResetTimeToWaitRoomsSpawn();

        StartCoroutine(WaitAllRoomsBeSpawned());

        roomsStorage = GameObject.Find("RoomsStorage").GetComponent<RoomsStorage>();
        interiorRoomSpawner = GameObject.Find("InteriorRoomSpawner").GetComponent<InteriorRoomSpawner>();
        interiorRoomStorage = GameObject.Find("InteriorRoomStorage").GetComponent<InteriorRoomStorage>();
        obstacleSpawner = GameObject.Find("ObstacleSpawner").GetComponent<ObstacleSpawner>();
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();

    }

    private void PrepareScenario()
    {
        // Aqui conterá todas as chamadas necessárias para gerenciar a criação do cenário
        roomsStorage.CollectAllSpawnedRooms();
        interiorRoomSpawner.SpawnInteriorRoomsTemplates();
        interiorRoomStorage.CollectAllSpawnedInteriorTemplates();
        obstacleSpawner.SpawnObstacles();
        enemySpawner.SpawnEnemies();
    }

    private IEnumerator WaitAllRoomsBeSpawned()
    {
        while (IsRoomsSpawning())
        {
            yield return new WaitForSeconds(ScenarioConstants.TIME_TO_GENERATE_NEW_ROOM + ScenarioConstants.MARGIN_OF_ERROR_TO_WAIT_ROOMS_SPAWN);
        }

        PrepareScenario();
        StopCoroutine(WaitAllRoomsBeSpawned());
    }

    private bool IsRoomsSpawning()
    {
        return timeUtils.GetGameTimeInMilliseconds() < timeToWaitRoomsSpawn;
    }

    public void ResetTimeToWaitRoomsSpawn()
    {
        timeToWaitRoomsSpawn = timeUtils.GetGameTimeInMilliseconds()
            + timeUtils.GetTimeInMilliseconds(ScenarioConstants.TIME_TO_GENERATE_NEW_ROOM)
            + timeUtils.GetTimeInMilliseconds(ScenarioConstants.MARGIN_OF_ERROR_TO_WAIT_ROOMS_SPAWN);
    }
}
