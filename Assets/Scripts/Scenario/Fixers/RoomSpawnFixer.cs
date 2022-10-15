using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomSpawnFixer
{
    private RoomTemplates roomTemplates;

    public void ReplaceClosedRoomsForComplementaryRooms()
    {
        new ScenarioOptmizer().DestroyClosedRoomsWithEqualPositions();
        GameObject[] closedRooms = GameObject.FindGameObjectsWithTag("ClosedRoom");

        if (closedRooms.Length == 0)
        {
            return;
        }

        if (roomTemplates == null)
        {
            roomTemplates = GameObject.FindGameObjectWithTag("RoomTemplates").GetComponent<RoomTemplates>();
        }

        RoomSpawnChecker roomSpawnChecker = new RoomSpawnChecker();
        for (int i = 0; i < closedRooms.Length; i++)
        {
            Vector3 closedRoomPosition = new Vector3(
                closedRooms[i].gameObject.transform.position.x,
                closedRooms[i].gameObject.transform.position.y,
                closedRooms[i].gameObject.transform.position.z
            );

            GameObject.Destroy(closedRooms[i].gameObject);
            GameObject choosedComplementaryRoom = GetComplementaryRoomFromPassagesDirections(
                roomSpawnChecker.GetPassagesDirections(closedRoomPosition)
            );

            float x = closedRoomPosition.x + ScenarioConstants.X_SPAWN_MARGIN_OF_ERROR;
            float y = closedRoomPosition.y + ScenarioConstants.Y_SPAWN_MARGIN_OF_ERROR;
            float z = closedRoomPosition.z;

            Vector3 position = new Vector3(x, y, z);
            Quaternion rotation = choosedComplementaryRoom.transform.rotation;

            GameObject.Instantiate(choosedComplementaryRoom, position, rotation);
        }
    }

    private GameObject GetComplementaryRoomFromPassagesDirections(List<Direction> passagesDirections)
    {
        foreach (GameObject complementaryRoom in roomTemplates.complementaryRooms)
        {
            List<Direction> complementaryRoomOpenedDirections =
                complementaryRoom.transform.Find("Data").GetComponent<OpenedDirectionsData>().openedDirections.ToList();

            complementaryRoomOpenedDirections.Sort();
            passagesDirections.Sort();

            if (Enumerable.SequenceEqual(complementaryRoomOpenedDirections, passagesDirections))
            {
                return complementaryRoom;
            }
        }

        return null;
    }
}
