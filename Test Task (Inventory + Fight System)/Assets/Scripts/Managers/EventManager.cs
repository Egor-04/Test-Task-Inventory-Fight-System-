using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action<Cell, Item> onCellClicked;
}
