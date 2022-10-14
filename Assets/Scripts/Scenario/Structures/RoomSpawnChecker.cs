using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawnChecker
{
    public void GetRoomsDoorsOpeningDirectionsBlocked(GameObject spawnPoint)
    {
        // OBS: o RoomSpawnChecker cria os objetos na hora, coleta o que precisa retorna o valor e se destroy depois
        // criar o raycast para cada direção (UP, DOWN, LEFT, RIGHT)
        // ver se ele bate em uma parede, dentro dos limites de distância, para não pegar a parede do outro lado do cenário
        // pegar todas as direcoes que bateram em paredes
        // retornar em um array ou lista
    }
}
