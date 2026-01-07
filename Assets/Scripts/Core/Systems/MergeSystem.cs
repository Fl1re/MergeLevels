using UnityEngine;

public class MergeSystem : MonoBehaviour, IMergeService
{
    public bool TryMerge(FieldEntity dragged, FieldEntity target)
    {
        if (dragged == target || !dragged.CanMerge(target)) return false;

        var registry = Services.Get<IConfigRegistry>();
        var nextConfig = dragged.GetNextConfig(registry);
        if (nextConfig == null) return false;

        CellView targetCell = target.CurrentCell;
        CellView draggedCell = dragged.CurrentCell;

        draggedCell.Clear();
        targetCell.Clear();

        Destroy(dragged.gameObject);
        Destroy(target.gameObject);

        var factory = Services.Get<IEntityFactory>();
        FieldEntity merged = factory.Create(nextConfig);

        targetCell.SetEntity(merged);

        return true;
    }
}
