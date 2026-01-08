public class ItemEntity : FieldEntity
{
    public ItemConfig Config { get; private set; }

    public void Initialize(ItemConfig config)
    {
        Config = config;
        Level = config.Level;
        entityName.text = $"i{Level}";
    }

    public override bool CanMerge(FieldEntity other)
    {
        return other.GetType() == GetType() && other.Level == Level;
    }
    
    public override ConfigBase GetNextConfig(IConfigRegistry registry)
    {
        return registry.GetItemConfig(Level + 1);
    }
}
