using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int MonyPlyer;
    [SerializeField] private int MoneyDiler;

    private void OnMouseEnter()
    {
        transform.DOScale(Vector3.one * 1.1f, 0.3f);
    }
}
