using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform originalParent;
    private Vector3 originalPosition;
    private FieldEntity entity;
    private Graphic graphic;

    private void Awake()
    {
        entity = GetComponent<FieldEntity>();
        graphic = GetComponent<Graphic>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        originalPosition = transform.position;

        graphic.raycastTarget = false;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        graphic.raycastTarget = true;

        var targetEntity = eventData.pointerEnter?.GetComponentInParent<FieldEntity>();

        if (targetEntity != null &&
            Services.Get<IMergeService>().TryMerge(entity, targetEntity))
        {
            return;
        }

        var targetCell = eventData.pointerEnter?.GetComponentInParent<CellView>();

        if (targetCell != null && targetCell.IsEmpty)
        {
            MoveToCell(targetCell);
            return;
        }

        ReturnBack();
    }
    
    private void MoveToCell(CellView targetCell)
    {
        var sourceCell = entity.CurrentCell;

        targetCell.SetEntity(entity);
        sourceCell.Clear();

        var rt = entity.GetComponent<RectTransform>();
        rt.anchoredPosition = Vector2.zero;
        rt.sizeDelta = Vector2.zero;
    }

    private void ReturnBack()
    {
        transform.SetParent(originalParent);
        transform.position = originalPosition;
    }
}
