using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Cell : MonoBehaviour
{
    public int Quantity;
    public Image IconImage;
    public TMP_Text QuantityText;
    public GameObject _popUpPanel;
    public Item ItemInCell;

    public void SetCellParameters()
    {
        Quantity = ItemInCell.MaxQuantity;
    }

    public void OpenPopUpPanel()
    {
        if (ItemInCell != null)
        {
            _popUpPanel.SetActive(true);
        }
    }


}
