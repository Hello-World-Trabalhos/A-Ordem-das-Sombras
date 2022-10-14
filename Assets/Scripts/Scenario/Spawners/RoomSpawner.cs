using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    private static RoomTemplates roomTemplates;
    private static RoomSpawnWait roomSpawnWait;

    public Direction roomConnectedDoorDirection;
    private bool isSpawned = false;

    void Start()
    {
        if (roomTemplates == null)
        {
            roomTemplates = GameObject.FindGameObjectWithTag("RoomTemplates").GetComponent<RoomTemplates>();
        }

        if (roomSpawnWait == null)
        {
            roomSpawnWait = GameObject.Find("RoomSpawnWait").GetComponent<RoomSpawnWait>();
        }

        Parallel.Invoke(() =>
        {
            Invoke("SpawnRoom", ScenarioConstants.TIME_TO_GENERATE_NEW_ROOM);
        });

        roomSpawnWait.ResetTimeToWaitRoomsSpawn();
    }

    private void SpawnRoom()
    {

        if (!isSpawned)
        {
            int randomIndex;
            GameObject choosedRoomTemplate = null;

            // adicionar aqui o SpawnChecker, irá retornar uma estrutura de dados informando quais lados não podem
            // estar abertos, e então, filtrar isso nos respectivos arrays


            switch (roomConnectedDoorDirection)
            {
                case Direction.TOP:
                    // filtragem do array
                    // cópia do array aqui
                    randomIndex = Random.Range(0, roomTemplates.topRooms.Length);
                    // usar cópia do array aqui
                    choosedRoomTemplate = roomTemplates.topRooms[randomIndex];
                    break;

                case Direction.LEFT:
                    // filtragem do array
                    // cópia do array aqui
                    randomIndex = Random.Range(0, roomTemplates.leftRooms.Length);
                    // usar cópia do array aqui
                    choosedRoomTemplate = roomTemplates.leftRooms[randomIndex];
                    break;

                case Direction.BOTTOM:
                    // filtragem do array
                    // cópia do array aqui
                    randomIndex = Random.Range(0, roomTemplates.bottomRooms.Length);
                    // usar cópia do array aqui
                    choosedRoomTemplate = roomTemplates.bottomRooms[randomIndex];
                    break;

                case Direction.RIGHT:
                    // filtragem do array
                    // cópia do array aqui
                    randomIndex = Random.Range(0, roomTemplates.rightRooms.Length);
                    // usar cópia do array aqui
                    choosedRoomTemplate = roomTemplates.rightRooms[randomIndex];
                    break;
            }

            float x = transform.position.x + ScenarioConstants.X_SPAWN_MARGIN_OF_ERROR;
            float y = transform.position.y + ScenarioConstants.Y_SPAWN_MARGIN_OF_ERROR;
            float z = transform.position.z;

            Vector3 position = new Vector3(x, y, z);
            Quaternion rotation = choosedRoomTemplate.transform.rotation;

            Instantiate(choosedRoomTemplate, position, rotation);

            isSpawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("RoomSpawnPoint"))
        {
            if (!other.GetComponent<RoomSpawner>().isSpawned && !isSpawned)
            {
                Instantiate(roomTemplates.closedRoom, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}
