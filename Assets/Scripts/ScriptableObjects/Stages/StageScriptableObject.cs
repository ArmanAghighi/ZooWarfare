using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Stage", menuName = "ScriptableObjects/Stage")]
public class StageScriptableObject : ScriptableObject
{
    public List<Stage> Waves;
}

[System.Serializable]
public class Stage
{
    public float WaveStartDelayTime;
    public bool HasGenerated;
    public List<WaveInfo> Enemy;
}

[System.Serializable]
public class WaveInfo
{
    public GameObject Enemy;
    public Vector3 EnemyPosition;
    public float RespawnTimeDelay;
}
