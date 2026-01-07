using TMPro;
using UnityEngine;

public class ItemEntity : FieldEntity
{
    [SerializeField] private TMP_Text itemName;

    public ItemConfig Config { get; private set; }

    public void Initialize(ItemConfig config)
    {
        Config = config;
        Level = config.Level;
        itemName.text = $"i{Level}";
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
