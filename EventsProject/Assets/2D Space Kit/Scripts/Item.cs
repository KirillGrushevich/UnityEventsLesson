using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int cost;
    public Type Type;
}

public enum Owner
{
    Player,
    Seller
}

public enum Type
{
    Yellow,
    Pink,
    Green,
    Blue,
    Black
}
