using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Shop : Owner {
    private void Start() {
        _text.text = "Money: " + _money.ToString();
        _inventory.Initialize(Buy);
    }

    public override void Buy(Item item) {
        if (_money >= item.Cost) {
            try {
                _inventory.TryAdd(item);
                _money -= item.Cost;
                item.Owner = this;
                _text.text = "Money: " + _money;
                
                item.transform.DORotate(new Vector3(0, 0, 180), 0.25f, RotateMode.LocalAxisAdd);
                Debug.Log("Shop buy");
            }
            catch (InvalidOperationException e) {
                Debug.Log("Error shop buy");
                return;
            }
        }
    }

    public override void Sell(Item item) {
        try {
            _inventory.TryRemove(item);
            _money += item.Cost;
            
            _text.text = "Money: " + _money;
        }
        catch (InvalidOperationException e) {
            Debug.Log("Error shop sell");
            return;
        }
    }
}
