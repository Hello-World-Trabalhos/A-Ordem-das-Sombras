using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioGenerationManager : MonoBehaviour
{

    private RoomsStorage roomsStorage;
    private InteriorRoomSpawner interiorRoomSpawner;
    private InteriorRoomStorage interiorRoomStorage;

    void Start()
    {
        roomsStorage = GameObject.Find("RoomsStorage").GetComponent<RoomsStorage>();
        interiorRoomSpawner = GameObject.Find("InteriorRoomSpawner").GetComponent<InteriorRoomSpawner>();
        interiorRoomStorage = GameObject.Find("InteriorRoomStorage").GetComponent<InteriorRoomStorage>();
        
        Invoke("PrepareScenario", ScenarioConstants.TIME_TO_START_SCENARIO_PREPARATION);
    }

    private void PrepareScenario()
    {
        // Aqui conterá todas as chamadas necessárias para gerenciar a criação do cenário
        roomsStorage.CollectAllSpawnedRooms();
        interiorRoomSpawner.SpawnInteriorRoomsTemplates();
        interiorRoomStorage.CollectAllSpawnedInteriorTemplates();

    }
}
