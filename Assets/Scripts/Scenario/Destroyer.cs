using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // TODO: Depois alterar o nome desse SpawnPointDestroyer, pois ele poderá
        // ser usado para destruir os quartos fechados também
        // outro ponto é ter cuidado para não destruir o player que entrar na área
        // desse objeto
        // TODO: fazer as tratativas comparando e vendo se os objetos são esses mesmos
        switch (other.tag)
        {
            case "RoomSpawnPoint":
                Debug.Log("Destruindo RoomSpawnPoint que colidiu no destroyer");
                Destroy(other.gameObject);
                break;

            case "ClosedRoom":
                // Destruir o closed room, evitando que ele fique dentro de um room sem querer
                Debug.Log("Destruindo ClosedRoom que colidiu no destroyer");
                break;
        }
    }
}
