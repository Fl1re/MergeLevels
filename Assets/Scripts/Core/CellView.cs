using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellView : MonoBehaviour
{
    public FieldEntity CurrentEntity { get; private set; }
    public bool IsEmpty => CurrentEntity == null;

    public void SetEntity(FieldEntity entity)
    {
        CurrentEntity = entity;
        entity.SetCell(this);
        entity.transform.SetParent(transform, false);
        entity.transform.localPosition = Vector3.zero;
    }

    public void Clear()
    {
        CurrentEntity = null;
    }
}
