using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    private const float X_SPAWN_MARGIN_OF_ERROR = -4.5f;
    private const float Y_SPAWN_MARGIN_OF_ERROR = 5.5f;

    public enum Direction
    {
        TOP, LEFT, BOTTOM, RIGHT
    }

    private static RoomTemplates roomTemplates;

    public Direction roomConnectedDoorDirection;
    private bool isSpawned = false;

    void Start()
    {
        if (roomTemplates == null)
        {
            roomTemplates = GameObject.FindGameObjectWithTag("RoomTemplates").GetComponent<RoomTemplates>();
        }

        Invoke("SpawnRoom", 0.3f);

    }

    private void SpawnRoom()
    {

        if (!isSpawned)
        {
            int randomIndex;
            GameObject choosedRoomTemplate = null;

            switch (roomConnectedDoorDirection)
            {
                case Direction.TOP:
                    randomIndex = Random.Range(0, roomTemplates.topRooms.Length);
                    choosedRoomTemplate = roomTemplates.topRooms[randomIndex];
                    break;

                case Direction.LEFT:
                    randomIndex = Random.Range(0, roomTemplates.leftRooms.Length);
                    choosedRoomTemplate = roomTemplates.leftRooms[randomIndex];
                    break;

                case Direction.BOTTOM:
                    randomIndex = Random.Range(0, roomTemplates.bottomRooms.Length);
                    choosedRoomTemplate = roomTemplates.bottomRooms[randomIndex];
                    break;

                case Direction.RIGHT:
                    randomIndex = Random.Range(0, roomTemplates.rightRooms.Length);
                    choosedRoomTemplate = roomTemplates.rightRooms[randomIndex];
                    break;
            }

            float x = transform.position.x + X_SPAWN_MARGIN_OF_ERROR;
            float y = transform.position.y + Y_SPAWN_MARGIN_OF_ERROR;
            float z = transform.position.z;

            Vector3 position = new Vector3(x, y, z);
            Quaternion rotation = choosedRoomTemplate.transform.rotation;

            Instantiate(choosedRoomTemplate, position, rotation);

            isSpawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // TODO: Fazer um if aqui verficando se a tag é Destroyer, se for, o objeto aqui se auto
        // destrói, Destroy(gameObjetct);
        if (other.CompareTag("RoomSpawnPoint"))
        {
            
            if (!other.GetComponent<RoomSpawner>().isSpawned && !isSpawned)
            {
                // TODO: Continuar implementando e tentando melhorar o código
                // Aparentemente não está OK, em alguns casos aparece esse quarto dentro dos outros
                // e em quantias bem maiores, exemplo, dão spawn de 15 desses objetos, mas só 1 aparece
                // uso de memória desnecessário
                // Pensar na possibilidade de colocar o SpawnPointDestroyer em todos os quartos
                // Assim sempre destrói o que aparecer ali
                //Instantiate(roomTemplates.closedRoom, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}
