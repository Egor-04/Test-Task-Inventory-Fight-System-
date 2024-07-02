using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Health
{
    [SerializeField] private Cell _headEquipment;

    protected override void TakeDamageToBody(int damageValue)
    {
        _healthValue -= damageValue;
        _healthText.text = _healthValue.ToString();
    }

    protected override void TakeDamageToHead(int damageValue)
    {
        throw new System.NotImplementedException();
    }
}
