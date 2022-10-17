using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    private static readonly RoomSpawnChecker roomSpawnChecker = new RoomSpawnChecker();
    private static Dictionary<Direction, GameObject[]> directionsRoomTemplates;
    private static RoomsStorage roomsStorage;
    private static RoomTemplates roomTemplates;
    private static RoomSpawnWait roomSpawnWait;

    public Direction roomConnectedDoorDirection;
    private bool isSpawned = false;

    void Start()
    {
        if (roomTemplates == null || directionsRoomTemplates == null)
        {
            roomTemplates = GameObject.FindGameObjectWithTag("RoomTemplates").GetComponent<RoomTemplates>();
            directionsRoomTemplates = new Dictionary<Direction, GameObject[]>();
            directionsRoomTemplates.Add(Direction.TOP, roomTemplates.topRooms);
            directionsRoomTemplates.Add(Direction.LEFT, roomTemplates.leftRooms);
            directionsRoomTemplates.Add(Direction.BOTTOM, roomTemplates.bottomRooms);
            directionsRoomTemplates.Add(Direction.RIGHT, roomTemplates.rightRooms);
        }

        if (roomsStorage == null)
        {
            roomsStorage = GameObject.Find("RoomsStorage").GetComponent<RoomsStorage>();
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
            List<Direction> blockedDirections = roomSpawnChecker.GetBlockedDirections(gameObject.transform.position);
            List<GameObject> choosedRoomTemplateArrayCopiedAsList = directionsRoomTemplates[roomConnectedDoorDirection].ToList();
            List<GameObject> choosedRoomtemplatesListFiltered = choosedRoomTemplateArrayCopiedAsList.FindAll(roomTemplate =>
            {
                OpenedDirectionsData roomOpenedDirectionsData = roomTemplate.transform.Find("Data").GetComponent<OpenedDirectionsData>();

                foreach (Direction direction in roomOpenedDirectionsData.openedDirections)
                {
                    if (blockedDirections.Contains(direction))
                    {
                        return false;
                    }
                }

                return true;
            });

            int randomIndex = Random.Range(0, choosedRoomtemplatesListFiltered.Count);
            GameObject choosedRoomTemplate = choosedRoomtemplatesListFiltered[randomIndex];

            float x = transform.position.x + ScenarioConstants.X_SPAWN_MARGIN_OF_ERROR;
            float y = transform.position.y + ScenarioConstants.Y_SPAWN_MARGIN_OF_ERROR;
            float z = transform.position.z;

            Vector3 position = new Vector3(x, y, z);
            Quaternion rotation = choosedRoomTemplate.transform.rotation;

            GameObject roomInstance = Instantiate(choosedRoomTemplate, position, rotation);
            roomsStorage.AddToNoComplementaryRoomsList(roomInstance);

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
