using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioOptmizer : MonoBehaviour
{

    void Start()
    {
        // irá limpar da cena todos os objetos que não necessitam mais existirem

        // lembrando que a destruição do 
        //   ScenarioGenerationManager
        //   ScenarioGenerationViewerManager
        // deve ser feita por último, pois é aquele que realiza isso
        // ou talvez um destroy com await, tipo, destroy(obj, depoisNSegundos)
    }
}
