using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsStorage : MonoBehaviour
{
    private GameObject[] spawnedRooms;
    private GameObject lastSpawnedRoom;

    public void CollectAllSpawnedRooms()
    {
        spawnedRooms = GameObject.FindGameObjectsWithTag("Room");
        lastSpawnedRoom = spawnedRooms[spawnedRooms.Length - 1];
    }

    public GameObject[] GetSpawnedRooms()
    {
        return spawnedRooms;
    }

    public GameObject GetLastSpawnedRoom()
    {
        return lastSpawnedRoom;
    }
}
