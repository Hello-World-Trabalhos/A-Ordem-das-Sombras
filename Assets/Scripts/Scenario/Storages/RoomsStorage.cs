using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsStorage : MonoBehaviour
{
    private GameObject[] spawnedRooms;

    public void CollectAllSpawnedRooms()
    {
        spawnedRooms = GameObject.FindGameObjectsWithTag("Room");
    }

    public GameObject[] GetSpawnedRooms()
    {
        if (spawnedRooms == null)
        {
            CollectAllSpawnedRooms();
        }

        return spawnedRooms;
    }

    public GameObject GetPlayerRoom()
    {
        if (spawnedRooms == null)
        {
            CollectAllSpawnedRooms();
        }
        
        return spawnedRooms[0];
    }

    public GameObject GetBossRoom()
    {
        if (spawnedRooms == null)
        {
            CollectAllSpawnedRooms();
        }
        
        return spawnedRooms[spawnedRooms.Length - 1];
    }
}
