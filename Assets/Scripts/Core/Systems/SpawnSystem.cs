using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour, ISpawnService
{
    [SerializeField] private FieldView field;

    public void SpawnItemFrom(SpawnerEntity spawner)
    {
        if (!field.TryGetFreeCell(out var cell)) return;

        ItemConfig config = Roll(spawner.Config.SpawnTable);

        var factory = Services.Get<IEntityFactory>();
        var item = factory.CreateItem(config);

        cell.SetEntity(item);
    }

    private ItemConfig Roll(List<SpawnChance> table)
    {
        float roll = Random.value;
        float sum = 0f;

        for (int i = 0; i < table.Count; i++)
        {
            sum += table[i].Chance;
            if (roll <= sum)
                return table[i].Item;
        }

        return table[^1].Item;
    }
}
