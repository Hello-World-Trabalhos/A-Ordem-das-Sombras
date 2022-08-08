using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsStorage : MonoBehaviour
{
    // lembrar de deixar assim, porque talvez se durante a geração quiser colocar um obstáculo
    // ou um item específico em um room aleatório, é possível também já com essas referências guardadas
    private GameObject[] roomsSpawned;
    private GameObject lastRoomSpawned;

    void Start()
    {
        // Talvez aqui ir incrementando o timer, até que realmente possa ser contado, tipo, para cada
        // room que aparece no cenário, vai incrementando aqui
        Invoke("FindLastSpawnedRoom", ScenarioConstants.TIME_TO_GET_ALL_ROOMS_SPAWNED);
    }

    private void FindLastSpawnedRoom()
    {
        roomsSpawned = GameObject.FindGameObjectsWithTag("Room");
        lastRoomSpawned = roomsSpawned[roomsSpawned.Length - 1];
    }

    public GameObject[] GetSpawnedRooms()
    {
        return roomsSpawned;
    }

    public GameObject GetLastSpawnedRoom()
    {
        return lastRoomSpawned;
    }
}
