using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsStorage : MonoBehaviour
{
    public GameObject[] spawnedRooms;
    public GameObject lastSpawnedRoom;

    void Start()
    {
        // Talvez aqui ir incrementando o timer, até que realmente possa ser contado, tipo, para cada
        // room que aparece no cenário, vai incrementando aqui
        Invoke("FindLastSpawnedRoom", ScenarioConstants.TIME_TO_GET_ALL_ROOMS_SPAWNED);
    }

    private void FindLastSpawnedRoom()
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
