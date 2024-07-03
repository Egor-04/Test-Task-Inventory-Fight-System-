using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopUpInfo : MonoBehaviour
{
    [SerializeField] private GameObject _popUpWindow; 
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _textNameItem;
    [SerializeField] private TMP_Text _itemPropertyText;
    [SerializeField] private Image _defaultPropertyImage;
    [SerializeField] private Sprite _ammoSprite, _medicineSprite, _equipmentSprite;
    [SerializeField] private Button _ammoButton, _medicineButton, _equipmentButton;
    private Cell _cell;
    private Item _item;

    private void Awake()
    {
        _ammoButton.onClick.AddListener(DoAction);
        _medicineButton.onClick.AddListener(DoAction);
        _equipmentButton.onClick.AddListener(DoAction);
    }

    public void SetInfo(Cell cell, Item item)
    {
        _popUpWindow.SetActive(true);
        _cell = cell;
        _item = item;

        switch (item)
        {
            case Ammo ammo:
                {
                    Debug.Log("AAAAAAAAAAAAAAA");
                    _icon.sprite = ammo.Icon;
                    _textNameItem.text = ammo.Name;
                    _defaultPropertyImage.sprite = _ammoSprite;
                    _itemPropertyText.text = "+" + ammo.MaxQuantity;
                    _ammoButton.gameObject.SetActive(true);
                    _medicineButton.gameObject.SetActive(false);
                    _equipmentButton.gameObject.SetActive(false); break;
                }
            case FirstAidKit kit:
                {
                    Debug.Log("BBBBBBBBBBBBBBBBBBBBBBBBB");
                    _icon.sprite = kit.Icon;
                    _textNameItem.text = kit.Name;
                    _defaultPropertyImage.sprite = _medicineSprite;
                    _itemPropertyText.text = "+" + kit.Healpoints;
                    _ammoButton.gameObject.SetActive(false);
                    _medicineButton.gameObject.SetActive(true);
                    _equipmentButton.gameObject.SetActive(false); break;
                }
            case Equipment equipment:
                {
                    Debug.Log("CCCCCCCCCCCCCCCCCCCCCCCCCCCC");
                    _icon.sprite = equipment.Icon;
                    _textNameItem.text = equipment.Name;
                    _defaultPropertyImage.sprite = _equipmentSprite;
                    _itemPropertyText.text = "+" + equipment.ArmorPoints;
                    _ammoButton.gameObject.SetActive(false);
                    _medicineButton.gameObject.SetActive(false);
                    _equipmentButton.gameObject.SetActive(true); break;
                }
        }
    }

    public void DoAction()
    {
        Debug.Log(_item.Name);
        _cell.UseItem(_item);
    }

    public void DeleteItem()
    {
        _cell.SetAsEmpty();
    }
}
