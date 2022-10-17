using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomsStorage : MonoBehaviour
{
    private GameObject[] allSpawnedRooms;
    private List<GameObject> noComplementarySpawnedRooms = new List<GameObject>();

    private void CollectAllSpawnedRooms()
    {
        allSpawnedRooms = GameObject.FindGameObjectsWithTag("Room");
    }

    public void AddToNoComplementaryRoomsList(GameObject room)
    {
        noComplementarySpawnedRooms.Add(room);
    }

    public List<GameObject> GetAllNoComplementaryRooms()
    {
        return noComplementarySpawnedRooms;
    }

    public GameObject[] GetAllSpawnedRooms()
    {
        if (allSpawnedRooms == null)
        {
            CollectAllSpawnedRooms();
        }

        return allSpawnedRooms;
    }

    public GameObject GetBossRoom()
    {
        return noComplementarySpawnedRooms.Last();
    }
}
