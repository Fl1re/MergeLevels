using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnChance
{
    public SpawnEntityType Type;
    public ConfigBase Config;
    [Range(0,1)]
    public float Chance;
}

[CreateAssetMenu(menuName = "Configs/Spawner")]
public class SpawnerConfig : ConfigBase
{
    public List<SpawnChance> SpawnTable;
}

public enum SpawnEntityType { Item, NonMergeItem }
