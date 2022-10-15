using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawnChecker
{
    private const float RAY_CAST_DISTANCE = 6.5f;
    public List<Direction> GetBlockedDirections(GameObject spawnPoint)
    {
        Vector2 positionUp = new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.y + 1);
        Vector2 positionLeft = new Vector2(spawnPoint.transform.position.x - 1, spawnPoint.transform.position.y);
        Vector2 positionDown = new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.y - 1);
        Vector2 positionRight = new Vector2(spawnPoint.transform.position.x + 1, spawnPoint.transform.position.y);

        List<Direction> directionsList = new List<Direction>();
        Dictionary<Direction, RaycastHit2D> hits = new Dictionary<Direction, RaycastHit2D>();
        hits.Add(Direction.TOP, Physics2D.Raycast(positionUp, Vector2.up, RAY_CAST_DISTANCE));
        hits.Add(Direction.LEFT, Physics2D.Raycast(positionLeft, Vector2.left, RAY_CAST_DISTANCE));
        hits.Add(Direction.BOTTOM, Physics2D.Raycast(positionDown, Vector2.down, RAY_CAST_DISTANCE));
        hits.Add(Direction.RIGHT, Physics2D.Raycast(positionRight, Vector2.right, RAY_CAST_DISTANCE));

        foreach (KeyValuePair<Direction, RaycastHit2D> hit in hits)
        {
            if (hit.Value.collider != null && hit.Value.collider.tag == "Wall")
            {
                directionsList.Add(hit.Key);
            }
        }

        return directionsList;
    }

    public List<Direction> GetPassagesDirections(GameObject spawnPoint)
    {
        // criar posições semelhante ao método acima
        // listar todos os lugares que tem colisões com um ponto chamado passage;
        // mudar o retorno aqui
        return new List<Direction>();
    }
}
