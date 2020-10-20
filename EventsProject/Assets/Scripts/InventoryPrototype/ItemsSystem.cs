using UnityEngine;
using Random = UnityEngine.Random;

public class ItemsSystem : MonoBehaviour
{
    public static ItemsSystem Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public ItemsList ItemsList;

    public int GetItemsCount => ItemsList.items.Count;
    public Item GetRandomItem() =>
        ItemsList.items.Count > 0 ? ItemsList.items[Random.Range(0, ItemsList.items.Count)] : null;
}
