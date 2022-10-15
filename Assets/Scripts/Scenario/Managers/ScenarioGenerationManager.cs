using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class ScenarioGenerationManager : MonoBehaviour
{

    private RoomsStorage roomsStorage;
    private InteriorRoomSpawner interiorRoomSpawner;
    private InteriorRoomStorage interiorRoomStorage;
    private ObstacleSpawner obstacleSpawner;
    private EnemySpawner enemySpawner;
    private BossSpawner bossSpawner;
    private PlayerSpawner playerSpawner;
    private RoomSpawnWait roomSpawnWait;

    private readonly ScenarioOptmizer scenarioOptmizer = new ScenarioOptmizer();
    private readonly RoomSpawnFixer roomSpawnFixer = new RoomSpawnFixer();
    private readonly TimeUtils timeUtils = new TimeUtils();


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
        roomSpawnFixer.ReplaceClosedRoomsForComplementaryRooms();
        interiorRoomSpawner.SpawnInteriorRoomsTemplates();
        obstacleSpawner.SpawnObstacles();
        enemySpawner.SpawnEnemies();
        bossSpawner.SpawnBoss();
        playerSpawner.SpawnPlayer();

        Parallel.Invoke(() => scenarioOptmizer.OptimizeScenario());
    }
}
