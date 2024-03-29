using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    private BossModels bossModels;
    private InteriorRoomStorage interiorRoomStorage;
    private GameObject spawnedBossReference;

    void Start()
    {
        bossModels = GameObject.Find("BossModels").GetComponent<BossModels>();
        interiorRoomStorage = GameObject.Find("InteriorRoomStorage").GetComponent<InteriorRoomStorage>();
    }

    public void SpawnBoss()
    {
        GameObject spawn = interiorRoomStorage.GetBossInteriorRoom().transform.Find("BossSpawns").transform.GetChild(0).gameObject;
        Vector3 spawnPosition = spawn.transform.position;
        Vector3 positionToSpawn = new Vector3(spawnPosition.x, spawnPosition.y, 0);

        GameObject bossModel = bossModels.bossModels[Random.Range(0, bossModels.bossModels.Length)];

        spawnedBossReference = Instantiate(bossModel, positionToSpawn, Quaternion.identity);
    }

    public void SpawnBossWithoutScripts()
    {
        SpawnBoss();
        new GameObjectUtils().DestroyAllScriptsInObject(spawnedBossReference);
    }
}
