using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldService : MonoBehaviour, IFieldService
{
    [SerializeField] private FieldView field;
    public FieldView GetField() => field;
}