public interface IEntityFactory
{
    FieldEntity CreateItem(ItemConfig config);
    FieldEntity CreateSpawner(SpawnerConfig config);
    FieldEntity CreateNonMergeable(NonMergeableItemConfig config);
    FieldEntity Create(ConfigBase config);
}
