using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggedItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject DraggedObject;
    public Inventory _inventory;

    [Header("Dragged Cell Parameters")]
    public Cell DraggedCell;
    public Image Icon;
    public TMP_Text QuantityText;

    public void SetCellInfo(Cell cell)
    {
        DraggedCell = cell;
        Icon.sprite = cell.GetItemInCell().Icon;
        QuantityText.text = cell.GetQuantity().ToString();
        QuantityText.enabled = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        DraggedObject = gameObject;
        _inventory.DraggedItemPrefab.gameObject.SetActive(true);
        _inventory.DraggedItemPrefab.GetComponent<CanvasGroup>().blocksRaycasts = false;

        if (TryGetComponent(out Cell cell) && cell.GetItemInCell() != null)
        {
            SetCellInfo(cell);
            QuantityText.enabled = cell.GetItemInCell().CanStack ? true : false;
        }
        else
        {
            _inventory.DraggedItemPrefab.gameObject.SetActive(false);
        }
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        _inventory.DraggedItemPrefab.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _inventory.DraggedItemPrefab.GetComponent<CanvasGroup>().blocksRaycasts = true;
        _inventory.DraggedItemPrefab.gameObject.SetActive(false);
    }
}
