using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{
    [SerializeField] private Item[] _allItems;
    [SerializeField] private Dictionary<int, Item> _itemDictionary;

    private void Awake()
    {
        _itemDictionary = new Dictionary<int, Item>();
        for (int i = 0; i < _allItems.Length; i++)
        {
            _itemDictionary.Add(_allItems[i].ID, _allItems[i]);
        }
    }

    public int GetItemdataLength()
    {
        return _allItems.Length; 
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