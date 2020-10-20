using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class InventoryItem : MonoBehaviour
{
    public string ItemName;
    public Sprite ItemSprite;
    public int Price;

    private void Reset()
    {
        ItemSprite = GetComponent<Image>().sprite;
    }
}
