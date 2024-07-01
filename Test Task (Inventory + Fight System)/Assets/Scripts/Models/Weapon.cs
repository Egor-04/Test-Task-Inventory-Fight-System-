using System;
using UnityEngine;

[Serializable]
public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int _id;
    [SerializeField] protected int _requiredAmmoID;
    [SerializeField] protected int _damageValue;
    [SerializeField] protected int _bulletDevreaseCount;
    [SerializeField] protected Inventory _inventory;

    private void Start()
    {
        _inventory = FindObjectOfType<Inventory>();
    }

    protected virtual void Shot()
    {
        if (_inventory.FindItem(_requiredAmmoID).GetType() == typeof(ItemDataBase))
        {
        }
    }
}
