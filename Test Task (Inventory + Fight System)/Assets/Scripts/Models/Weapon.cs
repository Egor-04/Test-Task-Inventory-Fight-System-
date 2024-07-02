using System;
using UnityEngine;

[Serializable]
public class Weapon : MonoBehaviour
{
    [SerializeField] protected int _requiredAmmoID;
    [SerializeField] protected int _damageValue;
    [SerializeField] protected int _bulletDevreaseCount;
    [SerializeField] protected Inventory _inventory;

    private void Start()
    {
        _inventory = FindObjectOfType<Inventory>();
    }

    public int Shot()
    {
        Cell ammo = _inventory.FindItem(_requiredAmmoID);
        if (ammo != null && ammo.GetQuantity() > 0)
        {
            ammo.DecreaseQuantity(_bulletDevreaseCount);
            return _damageValue;
        }
        return 0;
    }
}
