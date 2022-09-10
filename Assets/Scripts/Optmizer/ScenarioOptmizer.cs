using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ScenarioOptmizer
{
    public void OptimizeScenario()
    {
        DestroyInteriorTemplates();
        DestroyRoomsSpawnPoints();
        DestroyClosedRoomsWithEqualPositions();

        Debug.Log("Otimização do cenário finalizada!");
    }

    private void DestroyInteriorTemplates()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("InteriorTemplate");

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Object.Destroy(spawnPoints[i]);
        }

        Debug.Log("InteriorTemplates destroyed");
    }

    private void DestroyRoomsSpawnPoints()
    {
        GameObject[] rooms = GameObject.FindGameObjectsWithTag("Room");

        for (int i = 0; i < rooms.Length; i++)
        {
            Object.Destroy(rooms[i].transform.Find("SpawnPoints").gameObject);
        }

        Debug.Log("RoomsspawnPoints destroyed");
    }

    private void DestroyClosedRoomsWithEqualPositions()
    {

    }
}
