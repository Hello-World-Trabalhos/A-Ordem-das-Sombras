using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioGenerationManager : MonoBehaviour
{

    private RoomsStorage roomsStorage;
    private InteriorRoomSpawner interiorRoomSpawner;

    void Start()
    {
        roomsStorage = GameObject.Find("RoomsStorage").GetComponent<RoomsStorage>();
        interiorRoomSpawner = GameObject.Find("InteriorRoomSpawner").GetComponent<InteriorRoomSpawner>();

        Invoke("PrepareScenario", ScenarioConstants.TIME_TO_START_SCENARIO_PREPARATION);
    }

    private void PrepareScenario()
    {
        // Aqui conterá todas as chamadas necessárias para gerenciar a criação do cenário
        roomsStorage.CollectAllSpawnedRooms();
        interiorRoomSpawner.SpawnInteriorRoomsTemplates();
    }
}
