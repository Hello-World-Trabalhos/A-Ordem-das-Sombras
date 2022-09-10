using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawnWait : MonoBehaviour
{
    private TimeUtils timeUtils = new TimeUtils();
    private float timeToWaitRoomsSpawn;

    void Start()
    {
        ResetTimeToWaitRoomsSpawn();
    }

    public bool IsRoomsSpawning()
    {
        return timeUtils.GetGameTimeInMilliseconds() < timeToWaitRoomsSpawn;
    }

    public bool IsPossibleToStartScenarioPreparation()
    {
        return !IsRoomsSpawning();
    }

    public void ResetTimeToWaitRoomsSpawn()
    {
        timeToWaitRoomsSpawn = timeUtils.GetGameTimeInMilliseconds()
            + timeUtils.GetTimeInMilliseconds(ScenarioConstants.TIME_TO_GENERATE_NEW_ROOM)
            + timeUtils.GetTimeInMilliseconds(ScenarioConstants.MARGIN_OF_ERROR_TO_WAIT_ROOMS_SPAWN);
    }

    public float GetTimeToWaitRoomsSpawn()
    {
        return ScenarioConstants.TIME_TO_GENERATE_NEW_ROOM + ScenarioConstants.MARGIN_OF_ERROR_TO_WAIT_ROOMS_SPAWN;
    }
}
