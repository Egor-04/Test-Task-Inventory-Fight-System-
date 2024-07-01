using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Health
{
    [SerializeField] private int _healthValue;

    public void TakeDamage()
    {

    }

    protected override void TakeDamageToBody(int damageValue)
    {
        throw new System.NotImplementedException();
    }

    protected override void TakeDamageToHead(int damageValue)
    {
        throw new System.NotImplementedException();
    }
}
