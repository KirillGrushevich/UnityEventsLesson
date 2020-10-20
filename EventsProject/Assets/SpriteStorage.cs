using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpriteStorage : MonoBehaviour
{
    [SerializeField] private Sprite black;
    [SerializeField] private Sprite pink;
    [SerializeField] private Sprite yellow;
    [SerializeField] private Sprite green;
    [SerializeField] private Sprite blue;
    
    [SerializeField] private Sprite empty;
    [SerializeField] private Sprite full;

    public static SpriteStorage instance;
    public GameObject item;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public Sprite GetItemSprite(Item item)
    {
        switch (item.Type)
        {
            case Type.Black:
                return black;
            case Type.Blue:
                return blue;
            case Type.Green:
                return green;
            case Type.Pink:
                return pink;
            case Type.Yellow:
                return yellow;
        }

        return black;
    }

    public Sprite GetSellSprite(SellType type)
    {
        switch (type)
        {
            case SellType.Empty:
                return empty;
            case SellType.Full:
                return full;
        }

        return empty;
    }
}

public enum SellType
{
    Empty,
    Full
}
