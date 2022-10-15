using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawnChecker
{
    private const float RAY_CAST_DISTANCE = 6.5f;
    public List<Direction> GetBlockedDirections(Vector3 originPosition)
    {
        return CheckWhichDirectionsRayCastCollideByTag(originPosition, "Wall");
    }

    public List<Direction> GetPassagesDirections(Vector3 originPosition)
    {
        return CheckWhichDirectionsRayCastCollideByTag(originPosition, "Passage");
    }

    private List<Direction> CheckWhichDirectionsRayCastCollideByTag(Vector3 originPosition, string tag)
    {
        Vector2 positionUp = new Vector2(originPosition.x, originPosition.y + 1);
        Vector2 positionLeft = new Vector2(originPosition.x - 1, originPosition.y);
        Vector2 positionDown = new Vector2(originPosition.x, originPosition.y - 1);
        Vector2 positionRight = new Vector2(originPosition.x + 1, originPosition.y);

        List<Direction> directionsList = new List<Direction>();
        Dictionary<Direction, RaycastHit2D> hits = new Dictionary<Direction, RaycastHit2D>();
        hits.Add(Direction.TOP, Physics2D.Raycast(positionUp, Vector2.up, RAY_CAST_DISTANCE));
        hits.Add(Direction.LEFT, Physics2D.Raycast(positionLeft, Vector2.left, RAY_CAST_DISTANCE));
        hits.Add(Direction.BOTTOM, Physics2D.Raycast(positionDown, Vector2.down, RAY_CAST_DISTANCE));
        hits.Add(Direction.RIGHT, Physics2D.Raycast(positionRight, Vector2.right, RAY_CAST_DISTANCE));

        foreach (KeyValuePair<Direction, RaycastHit2D> hit in hits)
        {
            if (hit.Value.collider != null && hit.Value.collider.tag == tag)
            {
                directionsList.Add(hit.Key);
            }
        }

        return directionsList;
    }
}
