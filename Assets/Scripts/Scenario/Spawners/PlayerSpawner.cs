using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private PlayerModels playerModels;
    private InteriorRoomStorage interiorRoomStorage;
    private GameObject spawnedPlayerReference;

    void Start()
    {
        playerModels = GameObject.Find("PlayerModels").GetComponent<PlayerModels>();
        interiorRoomStorage = GameObject.Find("InteriorRoomStorage").GetComponent<InteriorRoomStorage>();
    }

    public void SpawnPlayer()
    {
        GameObject spawn = interiorRoomStorage.GetPlayerInteriorRoom().transform.Find("PlayerSpawns").transform.GetChild(0).gameObject;
        Vector3 spawnPosition = spawn.transform.position;
        Vector3 positionToSpawn = new Vector3(spawnPosition.x, spawnPosition.y, 0);

        spawnedPlayerReference = Instantiate(playerModels.playerModel, positionToSpawn, Quaternion.identity);
    }

    public void SpawnPlayerWithoutScript()
    {
        SpawnPlayer();
        MonoBehaviour[] playerScripts = spawnedPlayerReference.GetComponents<MonoBehaviour>();
        for (int i = 0; i < playerScripts.Length; i++)
        {
            Destroy(playerScripts[i]);
        }
    }
}
