using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnerEntity : FieldEntity, IPointerClickHandler
{
    public SpawnerConfig Config { get; private set; }
    
    [SerializeField] private TMP_Text spawnerName;

    public void Initialize(SpawnerConfig config)
    {
        Config = config;
        Level = config.Level;
        spawnerName.text = $"s{Level}";
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
