using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorRoomStorage : MonoBehaviour
{

    private GameObject[] spawnedInteriorRooms;
    private GameObject lastInteriorRoomSpawned;

    public void CollectAllSpawnedInteriorTemplates()
    {
        spawnedInteriorRooms = GameObject.FindGameObjectsWithTag("InteriorTemplate");
        lastInteriorRoomSpawned = spawnedInteriorRooms[spawnedInteriorRooms.Length - 1];
    }

    public GameObject[] getSpawnedInteriorRooms()
    {
        return spawnedInteriorRooms;
    }

    public GameObject getLastInteriorRoomSpawned()
    {
        return lastInteriorRoomSpawned;
    }
}
