using System;
using UnityEngine;

[Serializable]
public class Item : MonoBehaviour, IUsable
{
    public int ID;
    public string Name;
    public Sprite Icon;

    public int MaxQuantity;
    public float Weight;
    public bool CanStack;

    public virtual void Use()
    {
        throw new NotImplementedException();
    }
}
