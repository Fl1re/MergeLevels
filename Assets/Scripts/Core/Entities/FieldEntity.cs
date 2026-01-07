using UnityEngine;

public abstract class FieldEntity : MonoBehaviour
{
    public int Level { get; protected set; }
    public CellView CurrentCell { get; private set; }

    public void SetCell(CellView cell)
    {
        CurrentCell = cell;
    }

    public abstract bool CanMerge(FieldEntity other);

    public abstract ConfigBase GetNextConfig(IConfigRegistry registry);
}
