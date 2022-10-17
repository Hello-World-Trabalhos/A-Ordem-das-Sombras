using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteriorRoomStorage : MonoBehaviour
{

    private RoomsStorage roomsStorage;
    private GameObject[] spawnedInteriorRooms;

    void Start()
    {
        roomsStorage = GameObject.Find("RoomsStorage").GetComponent<RoomsStorage>();
    }

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
        GameObject lastSpawnedRoom = roomsStorage.GetAllNoComplementaryRooms().Last();
        int childNumber = lastSpawnedRoom.transform.childCount;

        for (int i = 0; i < childNumber; i++)
        {
            GameObject child = lastSpawnedRoom.transform.GetChild(i).gameObject;

            if (child.tag == "InteriorTemplate")
            {
                return child;
            }
        }

        return null;
    }
}
