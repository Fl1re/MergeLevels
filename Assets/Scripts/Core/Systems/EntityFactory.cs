using UnityEngine;

public class EntityFactory : MonoBehaviour, IEntityFactory
{
    [SerializeField] private ItemEntity itemPrefab;
    [SerializeField] private SpawnerEntity spawnerPrefab;

    public FieldEntity CreateItem(ItemConfig config)
    {
        var item = Instantiate(itemPrefab);
        item.Initialize(config);
        return item;
    }

    public FieldEntity CreateSpawner(SpawnerConfig config)
    {
        var spawner = Instantiate(spawnerPrefab);
        spawner.Initialize(config);
        return spawner;
    }

    public FieldEntity Create(ConfigBase config)
    {
        if (config is ItemConfig itemConfig)
            return CreateItem(itemConfig);
        if (config is SpawnerConfig spawnerConfig)
            return CreateSpawner(spawnerConfig);
        return null;
    }
}
