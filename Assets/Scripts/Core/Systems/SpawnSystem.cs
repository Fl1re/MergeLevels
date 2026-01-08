using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour, ISpawnService
{
    [SerializeField] private FieldView field;

    public void SpawnItemFrom(SpawnerEntity spawner)
    {
        if (!field.TryGetFreeCell(out var cell)) return;

        SpawnChance entry = Roll(spawner.Config.SpawnTable);
        var factory = Services.Get<IEntityFactory>();

        FieldEntity entity = entry.Type switch
        {
            SpawnEntityType.Item => factory.CreateItem((ItemConfig)entry.Config),
            SpawnEntityType.NonMergeItem => factory.CreateNonMergeable((NonMergeableItemConfig)entry.Config),
            _ => null
        };

        if (entity != null)
            cell.SetEntity(entity);
    }

    private SpawnChance Roll(List<SpawnChance> table)
    {
        float total = 0f;

        for (int i = 0; i < table.Count; i++)
            total += table[i].Chance;

        if (total <= 0f)
            return null;

        float roll = Random.value * total;
        float sum = 0f;

        for (int i = 0; i < table.Count; i++)
        {
            sum += table[i].Chance;
            if (roll <= sum)
                return table[i];
        }

        return table[^1];
    }
}
