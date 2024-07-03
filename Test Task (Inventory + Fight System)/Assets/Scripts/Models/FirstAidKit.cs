using System;

[Serializable]
public class FirstAidKit : Item
{
    public int Healpoints;

    public override void Use()
    {
        EventManager.onPlayerHeal?.Invoke(Healpoints);
    }
}
