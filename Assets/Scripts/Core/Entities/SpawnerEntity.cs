using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnerEntity : FieldEntity, IPointerClickHandler
{
    public SpawnerConfig Config { get; private set; }

    public void Initialize(SpawnerConfig config)
    {
        Config = config;
        Level = config.Level;
        entityName.text = $"s{Level}";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Services.Get<ISpawnService>().SpawnItemFrom(this);
    }

    public override bool CanMerge(FieldEntity other)
    {
        return other.GetType() == GetType() && other.Level == Level;
    }
    
    public override ConfigBase GetNextConfig(IConfigRegistry registry)
    {
        return registry.GetSpawnerConfig(Level + 1);
    }
}
