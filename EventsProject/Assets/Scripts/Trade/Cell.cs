using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private ItemType itemType;
    [SerializeField] private RectTransform rect;

    public RectTransform Rect => rect;
    public ItemType ItemType => itemType;
}

public enum ItemType
{
    Trader,
    Player
}
