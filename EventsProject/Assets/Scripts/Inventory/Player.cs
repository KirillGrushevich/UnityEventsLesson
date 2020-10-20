using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Player : Owner {

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
                _text.text = "Money: " + _money.ToString();

                item.transform.DORotate(Vector3.forward, 0.2f, RotateMode.LocalAxisAdd);
            }
            catch (InvalidOperationException e) {
                Debug.Log("Error player buy");
                return;
            }
        }
    }

    public override void Sell(Item item) {
        try {
            _inventory.TryRemove(item);
            _money += item.Cost;
            
            _text.text = "Money: " + _money.ToString();
            Debug.Log("Player sell");
        }
        catch (InvalidOperationException e) {
            Debug.Log("Error player sell");
            return;
        }
    }
}
