public class NonMergeableItemEntity : FieldEntity
{
    public ConfigBase Config { get; private set; }

    public void Initialize(ConfigBase config)
    {
        Config = config;
        entityName.text = "X";
    }

    public override bool CanMerge(FieldEntity other) => false;
    public override ConfigBase GetNextConfig(IConfigRegistry registry) => null;
}