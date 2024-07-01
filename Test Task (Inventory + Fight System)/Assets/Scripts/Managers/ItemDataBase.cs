using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{
    [SerializeField] private Item[] _allItems;
    [SerializeField] private Dictionary<int, Item> _itemDictionary;

    private void Awake()
    {
        _itemDictionary = new Dictionary<int, Item>();
        foreach (Item item in _allItems)
        {
            _itemDictionary.Add(item.ID, item);
        }
    }

    public Item FindItem(int itemID)
    {
        if (_itemDictionary.ContainsKey(itemID))
        {
            return _itemDictionary[itemID];
        }
        return null;
    }
}