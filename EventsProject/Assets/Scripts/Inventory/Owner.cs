using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Owner : MonoBehaviour, ISellCapable, IPurchasingCapable
{
    [SerializeField] protected Text _text;
    
    [SerializeField] protected Inventory _inventory;
    [SerializeField] protected float _money;
    
    public virtual void Buy(Item item) {
        throw new NotImplementedException();
    }

    public virtual void Sell(Item item) {
        throw new NotImplementedException();
    }
}
