using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioGeneratiorViewerConstants
{
    public const float MAX_X_CAMERA_AXIS = 150;
    public const float MAX_Y_CAMERA_AXIS = 150;
    public const float MIN_X_CAMERA_AXIS = MAX_X_CAMERA_AXIS * -1;
    public const float MIN_Y_CAMERA_AXIS = MAX_Y_CAMERA_AXIS * -1;
    public const float Z_CAMERA_AXIS = -10;
    public const int MIN_ENEMIES_AMMOUNT = 0;
    public const int MAX_ENEMIES_AMMOUNT = 4;

    public const string ENABLE_OBSTACLES_GENERATION = "ENABLE_OBSTACLES_GENERATION";
    public const string ENABLE_ENEMIES_GENERATION = "ENABLE_ENEMIES_GENERATION";
    public const string ENABLE_PLAYER_GENERATION = "ENABLE_PLAYER_GENERATION";
    public const string ENABLE_BOSS_GENERATION = "ENABLE_BOSS_GENERATION";
    public const string ENEMIES_AMOUNT = "ENEMIES_AMOUNT";
    public const string ENABLE_LIGHT_BACKGROUND = "ENABLE_LIGHT_BACKGROUND";

    public const bool ENABLE_OBSTACLES_GENERATION_DEFAULT_VALUE = true;
    public const bool ENABLE_ENEMIES_GENERATION_DEFAULT_VALUE = true;
    public const bool ENABLE_PLAYER_GENERATION_DEFAULT_VALUE = true;
    public const bool ENABLE_BOSS_GENERATION_DEFAULT_VALUE = true;
    public const int ENEMIES_AMOUNT_DEFAULT_VALUE = 2;
    public const bool ENABLE_LIGHT_BACKGROUND_DEFAULT_VALUE = false;
}
