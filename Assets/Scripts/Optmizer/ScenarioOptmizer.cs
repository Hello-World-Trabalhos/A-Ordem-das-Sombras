using System.Collections.Generic;
using UnityEngine;

public class ScenarioOptmizer
{
    public void OptimizeScenario()
    {
        DestroyInteriorTemplates();
        DestroyRoomsSpawnPoints();
        DestroyClosedRoomsWithEqualPositions();
        DestroyProceduralScenarioGenerationCreationItems();
    }

    private void DestroyInteriorTemplates()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("InteriorTemplate");

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Object.Destroy(spawnPoints[i]);
        }
    }

    private void DestroyRoomsSpawnPoints()
    {
        GameObject[] rooms = GameObject.FindGameObjectsWithTag("Room");

        for (int i = 0; i < rooms.Length; i++)
        {
            Object.Destroy(rooms[i].transform.Find("SpawnPoints").gameObject);
        }
    }

    private void DestroyClosedRoomsWithEqualPositions()
    {
        // Implementar ...
    }

    private void DestroyProceduralScenarioGenerationCreationItems()
    {
        GameObject proceduralScenarioGenerator = GameObject.Find("ProceduralScenarioGenerator").gameObject;

        GameObject.Destroy(proceduralScenarioGenerator.transform.Find("RoomsStorage").gameObject);
        GameObject.Destroy(proceduralScenarioGenerator.transform.Find("RoomTemplates").gameObject);
        GameObject.Destroy(proceduralScenarioGenerator.transform.Find("RoomSpawnWait").gameObject);
        GameObject.Destroy(proceduralScenarioGenerator.transform.Find("InteriorRoomTemplates").gameObject);
        GameObject.Destroy(proceduralScenarioGenerator.transform.Find("InteriorRoomStorage").gameObject);
        GameObject.Destroy(proceduralScenarioGenerator.transform.Find("InteriorRoomSpawner").gameObject);
        GameObject.Destroy(proceduralScenarioGenerator.transform.Find("ObstacleModels").gameObject);
        GameObject.Destroy(proceduralScenarioGenerator.transform.Find("ObstacleSpawner").gameObject);
        GameObject.Destroy(proceduralScenarioGenerator.transform.Find("EnemyModels").gameObject);
        GameObject.Destroy(proceduralScenarioGenerator.transform.Find("EnemySpawner").gameObject);
        GameObject.Destroy(proceduralScenarioGenerator.transform.Find("BossModels").gameObject);
        GameObject.Destroy(proceduralScenarioGenerator.transform.Find("BossSpawner").gameObject);
        GameObject.Destroy(proceduralScenarioGenerator.transform.Find("PlayerModels").gameObject);
        GameObject.Destroy(proceduralScenarioGenerator.transform.Find("PlayerSpawner").gameObject);

        Transform scenarioGenerationManager = proceduralScenarioGenerator.transform.Find("ScenarioGenerationManager");
        Transform scenarioGenerationViewerManager = proceduralScenarioGenerator.transform.Find("ScenarioGenerationViewerManager");

        if (scenarioGenerationManager != null)
        {
            GameObject.Destroy(scenarioGenerationManager.gameObject);
        }

        if (scenarioGenerationViewerManager != null)
        {
            GameObject.Destroy(scenarioGenerationViewerManager.gameObject);
        }
    }
}
