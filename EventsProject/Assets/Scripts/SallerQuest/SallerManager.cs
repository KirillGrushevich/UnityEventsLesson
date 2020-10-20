using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SallerManager : MonoBehaviour
{
    [SerializeField] private Sprite[] _playerItems;
    [SerializeField] private Sprite[] _sallerItems;
    [SerializeField] private Saller _basePItem;
    [SerializeField] private Saller _baseSItem;
    [SerializeField] private int _gold = 1000;
    [SerializeField] private int _coast = 10;
    [SerializeField] private Text _player;
    [SerializeField] private Text _saller;

    private int _playerGold = 0;
    private int _sallerGold = 0;
    private Saller[] _sItems;
    private Saller[] _pItems;
    void Start()
    {
        _pItems = new Saller[_playerItems.Length];
        _sItems = new Saller[_sallerItems.Length];

        for (int i = 0; i < _pItems.Length; i++)
        {
            _pItems[i] = Instantiate(_basePItem, _basePItem.transform.parent, true);
            _pItems[i].Setup(_playerItems[Random.Range(0, _playerItems.Length)], "Player");
        }
        for (int i = 0; i < _sItems.Length; i++)
        {
            _sItems[i] = Instantiate(_baseSItem, _baseSItem.transform.parent, true);
            _sItems[i].Setup(_sallerItems[Random.Range(0, _sallerItems.Length)], "Saller");
        }

        _playerGold = _sallerGold = _gold;
        _player.text = $"Player: {_playerGold}";
        _saller.text = $"Saller: {_sallerGold}";
    }

    public bool Buy(Saller item, string name)
    {
        switch (name)
        {
            case "Player":
            {
                if (_playerGold > _coast)
                {
                    _playerGold -= _coast;
                    _sallerGold += _coast;
                    var i = Instantiate(item, _baseSItem.transform.parent, true);
                    i.Setup(item.Img, "Saller");
                    _player.text = $"Player: {_playerGold}";
                    _saller.text = $"Saller: {_sallerGold}";
                    return true;
                }
                break;
            }
            case "Saller":
            {
                if (_sallerGold > _coast)
                {
                    _sallerGold -= _coast;
                    _playerGold += _coast;
                    var i = Instantiate(item, _basePItem.transform.parent, true);
                    i.Setup(item.Img, "Player");
                    _player.text = $"Player: {_playerGold}";
                    _saller.text = $"Saller: {_sallerGold}";
                    return true;
                }
                break;
            }
        }
        return false;
    }
}
