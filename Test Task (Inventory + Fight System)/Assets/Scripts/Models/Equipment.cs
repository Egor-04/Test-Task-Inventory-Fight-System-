using System;
using UnityEngine;

[Serializable]
public enum EquipmentType { Head, Body };
public class Equipment : Item
{
    public EquipmentType TypeOfEquipment; 
    public int ArmorPoints;
}
