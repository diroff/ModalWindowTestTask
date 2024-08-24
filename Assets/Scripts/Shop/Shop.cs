using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<ItemData> _availableItems;

    public List<ShopItem> CurrentItemsData { get; private set; } = new List<ShopItem>();

    private void Awake()
    {
        CreateShopItems();
    }

    private void CreateShopItems()
    {
        foreach (ItemData item in _availableItems)
        {
            CurrentItemsData.Add(new ShopItem(item));
        }
    }

    [ContextMenu("Show current shop Items")]
    public void DisplayShopItems()
    {
        foreach (ShopItem item in CurrentItemsData)
        {
            Debug.Log($"{item.ItemData.Name} - {item.ItemData.Description} - {item.ItemData.Cost}");
        }
    }
}