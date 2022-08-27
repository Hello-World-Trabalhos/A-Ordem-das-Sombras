using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorRoomSpawner : MonoBehaviour
{

    private RoomsStorage roomsStorage;
    private InteriorRoomTemplates interiorRoomTemplates;

    void Start()
    {
        roomsStorage = GameObject.Find("RoomsStorage").GetComponent<RoomsStorage>();
        interiorRoomTemplates = GameObject.Find("InteriorRoomTemplates").GetComponent<InteriorRoomTemplates>();
    }

    public void SpawnInteriorRoomsTemplates()
    {
        GameObject[] rooms = roomsStorage.GetSpawnedRooms();

        for (int i = 0; i < rooms.Length; i++)
        {
            int index = Random.Range(0, interiorRoomTemplates.interiorTemplates.Length);
            GameObject choosedInteriorRoomTemplate = interiorRoomTemplates.interiorTemplates[index].gameObject;

            Vector3 roomCenter = rooms[i].gameObject.transform.Find("SpawnPoints").Find("Destroyer").gameObject.transform.position;

            Quaternion rotation = choosedInteriorRoomTemplate.transform.rotation;

            Instantiate(choosedInteriorRoomTemplate, roomCenter, rotation);
        }
    }
}
