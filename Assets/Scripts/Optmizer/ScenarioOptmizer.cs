using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioOptmizer : MonoBehaviour
{

    void Start()
    {
        // irá guardar alguns dados, para quando tudo ser gerado, destruir o que não será mais usado para essa geração
        // como por exemplo, spawnpoints, destroyers, room templates, essas coisas, influsive esse proprio objeto
        // talvez inicialmente usar um invoke com um tempo, 10 segundos por exemplo, depois pensar em uma maneira
        // de chamar esse componente exatamente quando o boss spawnar
    }
}
