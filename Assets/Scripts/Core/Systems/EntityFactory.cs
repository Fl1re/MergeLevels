using UnityEngine;

public class EntityFactory : MonoBehaviour, IEntityFactory
{
    [SerializeField] private ItemEntity itemPrefab;
    [SerializeField] private SpawnerEntity spawnerPrefab;
    [SerializeField] private NonMergeableItemEntity nonMergeableItemPrefab;

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
    
    public FieldEntity CreateNonMergeable(NonMergeableItemConfig config)
    {
        var item = Instantiate(nonMergeableItemPrefab);
        item.Initialize(config);
        return item;
    }

    public FieldEntity Create(ConfigBase config)
    {
        if (config is ItemConfig itemConfig)
            return CreateItem(itemConfig);
        if (config is SpawnerConfig spawnerConfig)
            return CreateSpawner(spawnerConfig);
        if (config is NonMergeableItemConfig nm) 
            return CreateNonMergeable(nm);
        return null;
    }
}
