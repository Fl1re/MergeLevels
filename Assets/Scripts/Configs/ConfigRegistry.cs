using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/ConfigRegistry")]
public class ConfigRegistry : ScriptableObject, IConfigRegistry
{
    [SerializeField] private ItemConfig[] itemConfigs;
    [SerializeField] private SpawnerConfig[] spawnerConfigs;

    public ItemConfig GetItemConfig(int level) => level - 1 < itemConfigs.Length ? itemConfigs[level - 1] : null;
    public SpawnerConfig GetSpawnerConfig(int level) => level - 1 < spawnerConfigs.Length ? spawnerConfigs[level - 1] : null;
}
