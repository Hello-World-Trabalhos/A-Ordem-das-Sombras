using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioGenerationManager : MonoBehaviour
{

    private RoomsStorage roomsStorage;

    void Start()
    {
        roomsStorage = GameObject.Find("RoomsStorage").GetComponent<RoomsStorage>();

        Invoke("PrepareScenario", ScenarioConstants.TIME_TO_START_SCENARIO_PREPARATION);
    }

    private void PrepareScenario()
    {
        // Aqui conterá todas as chamadas necessárias para gerenciar a criação do cenário
        roomsStorage.CollectAllSpawnedRooms();
    }
}
