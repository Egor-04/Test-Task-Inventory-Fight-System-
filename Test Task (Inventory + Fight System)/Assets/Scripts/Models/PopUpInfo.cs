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
    [SerializeField] private Cell _cell;

    public void SetInfo(Cell cell, Item item)
    {
        _popUpWindow.SetActive(true);
        _cell = cell;

        switch (item)
        {
            case Ammo ammo:
                {
                    _icon.sprite = ammo.Icon;
                    _textNameItem.text = ammo.Name;
                    _defaultPropertyImage.sprite = _ammoSprite;
                    _itemPropertyText.text = "+" + ammo.MaxQuantity;
                    _ammoButton.onClick.AddListener(DoAction);
                    _ammoButton.gameObject.SetActive(true);
                    _medicineButton.gameObject.SetActive(false);
                    _equipmentButton.gameObject.SetActive(false); break;
                }
            case FirstAidKit kit:
                {
                    _icon.sprite = kit.Icon;
                    _textNameItem.text = kit.Name;
                    _defaultPropertyImage.sprite = _medicineSprite;
                    _itemPropertyText.text = "+" + kit.Healpoints;
                    _medicineButton.onClick.AddListener(DoAction);
                    _ammoButton.gameObject.SetActive(false);
                    _medicineButton.gameObject.SetActive(true);
                    _equipmentButton.gameObject.SetActive(false); break;
                }
            case Equipment equipment:
                {
                    _icon.sprite = equipment.Icon;
                    _textNameItem.text = equipment.Name;
                    _defaultPropertyImage.sprite = _equipmentSprite;
                    _itemPropertyText.text = "+" + equipment.ArmorPoints;
                    _equipmentButton.onClick.AddListener(DoAction);
                    _ammoButton.gameObject.SetActive(true);
                    _medicineButton.gameObject.SetActive(false);
                    _equipmentButton.gameObject.SetActive(true); break;
                }
        }
    }

    public void DoAction()
    {
        switch (_cell.GetItemInCell())
        {
            case Ammo ammo:
                {
                    Debug.Log("A");
                    break;
                }
            case FirstAidKit kit:
                {
                    Debug.Log("B");
                    break;
                }
            case Equipment equipment:
                {
                    Debug.Log("C");
                    break;
                }
        }
    }

    public void DeleteItem()
    {
        _cell.SetAsEmpty();
    }
}
