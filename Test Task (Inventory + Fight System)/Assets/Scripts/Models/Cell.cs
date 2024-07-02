using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
public class Cell : MonoBehaviour, IDropHandler, IPointerUpHandler
{
    [SerializeField] private int CurrentQuantity;
    [SerializeField] private Image IconImage;
    [SerializeField] private TMP_Text QuantityText;
    [SerializeField] private Item ItemInCell;

    [Header("Pop Up Window")]
    [SerializeField] private GameObject _popUpPanel;

    [Header("Equipment Options Only")]
    [SerializeField] private EquipmentType _equipmentType;
    [SerializeField] private bool _equipmentOnly;

    [Header("Temp Cell")]
    [SerializeField] private Cell _tempCell;

    private void Awake()
    {
        IconImage = transform.GetChild(0).GetComponent<Image>();
        QuantityText = transform.GetChild(1).GetComponent<TMP_Text>();
    }

    public int GetQuantity() { return CurrentQuantity; }

    public Item GetItemInCell() { return ItemInCell; }

    public void SetCellParameters(Item item)
    {
        ItemInCell = item;
        CurrentQuantity = item.MaxQuantity;
        IconImage.sprite = item.Icon;
        QuantityText.text = CurrentQuantity.ToString();

        if (item is Equipment equipment)
        {
            _equipmentType = equipment.TypeOfEquipment;
        }

        if (ItemInCell.CanStack)
        {
            QuantityText.enabled = true;
        }
        else
        {
            QuantityText.enabled = false;
        }
    }

    public void SetAsEmpty()
    {
        ItemInCell = null;
        CurrentQuantity = 0;
        IconImage.sprite = null;
        QuantityText.text = 0.ToString();
        QuantityText.enabled = false;
    }

    public void DecreaseQuantity(int value)
    {
        CurrentQuantity -= value;
    }

    public void OpenPopUpPanel()
    {
        if (ItemInCell != null && _popUpPanel != null)
        {
            _popUpPanel.SetActive(true);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedObj = DraggedItem.DraggedObject;
        Cell previousCellInfo = draggedObj.GetComponent<DraggedItem>().DraggedCell;

        if (previousCellInfo == null)
        {
            return;
        }

        if (_equipmentOnly)
        {
            if (previousCellInfo.ItemInCell is Equipment equipment)
            {
                if (equipment.TypeOfEquipment == _equipmentType && ItemInCell == null)
                {
                    SetCellParameters(equipment);
                }
                else
                {
                    _tempCell.SetCellParameters(ItemInCell);
                    SetCellParameters(previousCellInfo.ItemInCell);
                    previousCellInfo.SetCellParameters(_tempCell.ItemInCell);
                }
            }
        }
        else
        {
            if (ItemInCell == null && previousCellInfo.ItemInCell != null)
            {
                SetCellParameters(previousCellInfo.ItemInCell);
                previousCellInfo.SetAsEmpty();
            }
            else
            {
                _tempCell.SetCellParameters(ItemInCell);
                SetCellParameters(previousCellInfo.ItemInCell);
                previousCellInfo.SetCellParameters(_tempCell.ItemInCell);
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OpenPopUpPanel();
    }
}
