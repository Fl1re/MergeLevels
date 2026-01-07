using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnChance
{
    public ItemConfig Item;
    [Range(0f, 1f)] public float Chance;
}

[CreateAssetMenu(menuName = "Configs/Spawner")]
public class SpawnerConfig : ConfigBase
{
    public List<SpawnChance> SpawnTable;
}
