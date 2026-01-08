using TMPro;
using UnityEngine;

public abstract class FieldEntity : MonoBehaviour
{
    [SerializeField] protected TMP_Text entityName;
    public int Level { get; protected set; }
    public CellView CurrentCell { get; private set; }

    public void SetCell(CellView cell)
    {
        CurrentCell = cell;
    }

    public abstract bool CanMerge(FieldEntity other);

    public abstract ConfigBase GetNextConfig(IConfigRegistry registry);
}
