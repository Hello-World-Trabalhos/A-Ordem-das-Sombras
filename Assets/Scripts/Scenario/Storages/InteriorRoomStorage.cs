using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorRoomStorage : MonoBehaviour
{

    private GameObject[] spawnedInteriorRooms;

    public void CollectAllSpawnedInteriorTemplates()
    {
        spawnedInteriorRooms = GameObject.FindGameObjectsWithTag("InteriorTemplate");
    }

    public GameObject[] GetAllSpawnedInteriorRooms()
    {
        if (spawnedInteriorRooms == null)
        {
            CollectAllSpawnedInteriorTemplates();
        }

        return spawnedInteriorRooms;
    }

    public GameObject GetPlayerInteriorRoom()
    {
        if (spawnedInteriorRooms == null)
        {
            CollectAllSpawnedInteriorTemplates();
        }
        
        return spawnedInteriorRooms[0];
    }

    public GameObject GetBossInteriorRoom()
    {
        if (spawnedInteriorRooms == null)
        {
            CollectAllSpawnedInteriorTemplates();
        }
        
        return spawnedInteriorRooms[spawnedInteriorRooms.Length - 1];
    }
}
