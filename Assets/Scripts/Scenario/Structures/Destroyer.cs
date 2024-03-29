using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        
        switch (other.tag)
        {
            case "RoomSpawnPoint":
                Destroy(other.gameObject);
                break;

            case "Wall":
                Destroy(other.transform.parent.gameObject);
                break;

            case "Destroyer":
                Destroy(other.transform.parent.parent.gameObject);
                break;
        }
    }
}
