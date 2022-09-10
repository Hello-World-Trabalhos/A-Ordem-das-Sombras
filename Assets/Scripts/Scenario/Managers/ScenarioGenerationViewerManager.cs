using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ScenarioGenerationViewerManager : MonoBehaviour
{
    private RoomsStorage roomsStorage;
    private InteriorRoomSpawner interiorRoomSpawner;
    private InteriorRoomStorage interiorRoomStorage;
    private ObstacleSpawner obstacleSpawner;
    private EnemySpawner enemySpawner;
    private BossSpawner bossSpawner;
    private PlayerSpawner playerSpawner;
    private RoomSpawnWait roomSpawnWait;


    private ScenarioGenerationConfig scenarioGenerationConfig = new ScenarioGenerationConfig();
    private ScenarioOptmizer scenarioOptmizer = new ScenarioOptmizer();
    private TimeUtils timeUtils = new TimeUtils();

    void Start()
    {
        roomSpawnWait = GameObject.Find("RoomSpawnWait").GetComponent<RoomSpawnWait>();
        roomSpawnWait.ResetTimeToWaitRoomsSpawn();
        StartCoroutine(WaitAllRoomsBeSpawned());

        roomsStorage = GameObject.Find("RoomsStorage").GetComponent<RoomsStorage>();
        interiorRoomSpawner = GameObject.Find("InteriorRoomSpawner").GetComponent<InteriorRoomSpawner>();
        interiorRoomStorage = GameObject.Find("InteriorRoomStorage").GetComponent<InteriorRoomStorage>();
        obstacleSpawner = GameObject.Find("ObstacleSpawner").GetComponent<ObstacleSpawner>();
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        bossSpawner = GameObject.Find("BossSpawner").GetComponent<BossSpawner>();
        playerSpawner = GameObject.Find("PlayerSpawner").GetComponent<PlayerSpawner>();
    }

    private IEnumerator WaitAllRoomsBeSpawned()
    {
        while (!roomSpawnWait.IsPossibleToStartScenarioPreparation())
        {
            yield return new WaitForSeconds(roomSpawnWait.GetTimeToWaitRoomsSpawn());
        }

        PrepareScenario();
        StopCoroutine(WaitAllRoomsBeSpawned());
    }

    private void PrepareScenario()
    {
        interiorRoomSpawner.SpawnInteriorRoomsTemplates();
        if (scenarioGenerationConfig.IsObstacleGenerationEnabled())
        {
            obstacleSpawner.SpawnObstacles();
        }

        if (scenarioGenerationConfig.IsEnemyGenerationEnabled())
        {
            enemySpawner.SpawnEnemies(scenarioGenerationConfig.GetEnemiesAmmount());
        }

        if (scenarioGenerationConfig.IsBossGenerationEnabled())
        {
            bossSpawner.SpawnBoss();
        }

        if (scenarioGenerationConfig.IsPlayerGenerationEnabled())
        {
            playerSpawner.SpawnPlayer();
        }

        Parallel.Invoke(() => scenarioOptmizer.OptimizeScenario());
    }
}
