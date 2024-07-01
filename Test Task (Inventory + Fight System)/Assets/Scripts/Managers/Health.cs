using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] private int _healthValue;
    [SerializeField] private TMP_Text _healthText;

    protected abstract void TakeDamageToHead(int damageValue);

    protected abstract void TakeDamageToBody(int damageValue);
}
