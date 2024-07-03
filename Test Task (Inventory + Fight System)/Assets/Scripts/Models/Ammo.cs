using System;

[Serializable]
public class Ammo : Item
{
    public string Caliber;

    public override void Use()
    {
        EventManager.onBuyAmmo?.Invoke(ID);
    }
}
