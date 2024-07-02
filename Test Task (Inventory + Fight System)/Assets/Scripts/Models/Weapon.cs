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

    public int GetID() { return _id; }

    protected virtual void Shot()
    {
        Cell ammo = _inventory.FindItem(_requiredAmmoID);

        if (ammo != null && ammo.GetQuantity() > 0)
        {
            ammo.DecreaseQuantity(_bulletDevreaseCount);
            Debug.Log("Im shooting!");
        }
    }
}
