using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected int _healthValue;
    [SerializeField] protected TMP_Text _healthText;
    [SerializeField] protected Slider _healthBar;

    protected abstract void TakeDamageToHead(int damageValue);

    protected abstract void TakeDamageToBody(int damageValue);

    protected virtual void UpdateVisualInfo()
    {
        _healthBar.value = _healthValue;
        _healthText.text = _healthValue.ToString();
    }
}
