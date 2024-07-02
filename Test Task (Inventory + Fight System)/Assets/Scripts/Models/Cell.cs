using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
public class Cell : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    [SerializeField] private int _currentQuantity;
    [SerializeField] private Image _iconImage;
    [SerializeField] private TMP_Text _quantityText;
    [SerializeField] private Item _itemInCell;

    [Header("Equipment Options Only")]
    [SerializeField] private EquipmentType _equipmentType;
    [SerializeField] private int _armorValue;
    [SerializeField] private TMP_Text _armorValueText;
    [SerializeField] private bool _equipmentOnly;

    [Header("Temp Cell")]
    [SerializeField] private Cell _tempCell;

    private void Awake()
    {
        _iconImage = transform.GetChild(0).GetComponent<Image>();
        _quantityText = transform.GetChild(1).GetComponent<TMP_Text>();
    }

    public int GetQuantity() { return _currentQuantity; }

    public Item GetItemInCell() { return _itemInCell; }

    public void SetAsEmpty()
    {
        _itemInCell = null;
        _currentQuantity = 0;
        _iconImage.sprite = null;
        _quantityText.text = 0.ToString();
        _quantityText.enabled = false;

        if (_armorValueText)
        {
            _armorValue = 0;
            _armorValueText.text = _armorValue.ToString();
        }
    }

    public void SetCellParameters(Item item)
    {
        _itemInCell = item;
        _currentQuantity = item.MaxQuantity;
        _iconImage.sprite = item.Icon;
        _quantityText.text = _currentQuantity.ToString();

        if (item is Equipment equipment1 && _equipmentOnly == false)
        {
            _equipmentType = equipment1.TypeOfEquipment;
        }
        else if (item is Equipment equipment2 && _equipmentOnly)
        {
            _armorValue = equipment2.ArmorPoints;
            _armorValueText.text = equipment2.ArmorPoints.ToString();
        }

        if (_itemInCell.CanStack)
        {
            _quantityText.enabled = true;
        }
        else
        {
            _quantityText.enabled = false;
        }
    }

    public void DecreaseQuantity(int value)
    {
        if (_currentQuantity <= 0)
        {
            _currentQuantity = 0;
            _quantityText.text = _currentQuantity.ToString();
        }
        else
        {
            _currentQuantity -= value;
            _quantityText.text = _currentQuantity.ToString();
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
            if (previousCellInfo._itemInCell is Equipment equipment)
            {
                if (equipment.TypeOfEquipment == _equipmentType && _itemInCell == null)
                {
                    SetCellParameters(equipment);
                    previousCellInfo.SetAsEmpty();
                }
                else if (equipment.TypeOfEquipment == _equipmentType)
                {
                    _tempCell.SetCellParameters(_itemInCell);
                    SetCellParameters(previousCellInfo._itemInCell);
                    previousCellInfo.SetCellParameters(_tempCell._itemInCell);
                }
            }
        }
        else
        {
            if (_itemInCell == null && previousCellInfo._itemInCell != null)
            {
                SetCellParameters(previousCellInfo._itemInCell);
                previousCellInfo.SetAsEmpty();
            }
            else
            {
                if (previousCellInfo._equipmentOnly)
                {
                    if (previousCellInfo._itemInCell is Equipment && previousCellInfo._equipmentType == _equipmentType)
                    {
                        if (_itemInCell is Equipment)
                        {
                            _tempCell.SetCellParameters(_itemInCell);
                            SetCellParameters(previousCellInfo._itemInCell);
                            previousCellInfo.SetCellParameters(_tempCell._itemInCell);
                        }
                    }
                }
                else
                {
                    if (previousCellInfo._itemInCell != null)
                    {
                        _tempCell.SetCellParameters(_itemInCell);
                        SetCellParameters(previousCellInfo._itemInCell);
                        previousCellInfo.SetCellParameters(_tempCell._itemInCell);
                    }
                }
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_itemInCell != null)
        {
            EventManager.onCellClicked?.Invoke(this, _itemInCell);
        }
    }
}
