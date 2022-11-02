using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectUtils
{
    public void DestroyAllScriptsInObject(GameObject obj)
    {
        MonoBehaviour[] objScripts = obj.GetComponents<MonoBehaviour>();
        for (int i = 0; i < objScripts.Length; i++)
        {
            GameObject.Destroy(objScripts[i]);
        }
    }
}
