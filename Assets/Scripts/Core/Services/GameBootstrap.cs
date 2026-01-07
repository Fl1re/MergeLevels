using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private SpawnSystem spawnSystem;
    [SerializeField] private MergeSystem mergeSystem;
    [SerializeField] private EntityFactory entityFactory;
    [SerializeField] private ConfigRegistry configRegistry;
    [SerializeField] private FieldService fieldService;

    private void Awake()
    {
        Services.Clear();
        Services.Register<ISpawnService>(spawnSystem);
        Services.Register<IMergeService>(mergeSystem);
        Services.Register<IEntityFactory>(entityFactory);
        Services.Register<IConfigRegistry>(configRegistry);
        Services.Register<IFieldService>(fieldService);
        InitializeStartingSpawner();
    }

    private void InitializeStartingSpawner()
    {
        var fieldService = Services.Get<IFieldService>();
        var field = fieldService.GetField();

        if (!field.TryGetFreeCell(out var cell))
        {
            Debug.LogWarning("No free cell for starting spawner!");
            return;
        }

        var registry = Services.Get<IConfigRegistry>();
        var config = registry.GetSpawnerConfig(1);
        if (config == null)
        {
            Debug.LogError("No config for spawner level 1!");
            return;
        }

        var factory = Services.Get<IEntityFactory>();
        var spawner = factory.CreateSpawner(config);

        cell.SetEntity(spawner);
    }
}
