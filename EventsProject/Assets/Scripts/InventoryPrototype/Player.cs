using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance;
    private void Awake()
    {
        Instance = this;
    }

    private int _playerMoney;
    public int PlayerMoney
    {
        get => _playerMoney;
        set
        {
            _playerMoney = value;
            PlayerMoneyChanged(value);
        } 
    }
    
    // Start Values
    public int InitialPlayerMoney = 200;
    
    // UI
    [SerializeField] private Text moneyCounter;

    private void Start()
    {
        PlayerMoney = InitialPlayerMoney;
    }

    public bool BuyItem(int price)
    {
        Debug.Log(price);
        if (PlayerMoney >= price)
        {
            Debug.Log("Buy item");
            PlayerMoney -= price;
            return true;
        }
        return false;
    }
    
    public void PlayerMoneyChanged(int value)
    {
        moneyCounter.text = $"Money: {value}";
    }
}
