using System.Collections.Generic;
using UnityEngine;

public class FieldView : MonoBehaviour
{
    [SerializeField] private List<CellView> cells;

    public bool TryGetFreeCell(out CellView cell)
    {
        foreach (var c in cells)
        {
            if (c.IsEmpty)
            {
                cell = c;
                return true;
            }
        }
        cell = null;
        return false;
    }
}
