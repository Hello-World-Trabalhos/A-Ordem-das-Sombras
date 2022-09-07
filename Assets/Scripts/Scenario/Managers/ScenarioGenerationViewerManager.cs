using System.Collections;
using System.Collections.Generic;
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
        
        // verificar se geração de obstáculos está ativada ou não
        obstacleSpawner.SpawnObstacles();

        // verificar se os inimigos estão spawnados ou não
        // lembrar também de chamar o SpawnEnemies(quantiaInimigosSalvaNasConfigs)
        enemySpawner.SpawnEnemies();

        // verificar se a geração do boss está ativada ou não
        bossSpawner.SpawnBoss();

        // verificar se a geração do player está ativada ou não
        playerSpawner.SpawnPlayer();

        // adicionar verificacao da cor de fundo da camera
        //  deve alterar cor do fundo e a cor da engrenagem, por isso terá 2 sprites, um claro e outro escuro
        //  para dar destaque e a pessoa conseguir ver

        // adicionar o optimizer aqui
    }
}
