using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<ItemData> _availableItems;
    [SerializeField] private Wallet _wallet;

    public List<ShopItem> CurrentItemsData { get; private set; } = new List<ShopItem>();

    public UnityAction ShopWasUpdated;

    private void Awake()
    {
        CreateShopItems();
    }

    private void Start()
    {
        ShopWasUpdated?.Invoke();
    }

    private void CreateShopItems()
    {
        foreach (ItemData item in _availableItems)
        {
            var newItem = new ShopItem(item);

            CurrentItemsData.Add(newItem);
            newItem.ItemTryiedToBuy += OnItemTryiedToBuy;
        }
    }

    private void OnItemTryiedToBuy(ShopItem item)
    {
        TryToBuyItem(item);
    }

    public void TryToBuyItem(ShopItem item)
    {
        if (!CanBuyItem(item))
            return;

        item.BuyItem();
        item.ItemTryiedToBuy -= OnItemTryiedToBuy;

        _wallet.TryToSpendCoins(item.ItemData.Cost);

        ShopWasUpdated?.Invoke();
        CurrentItemsData.Remove(item);
    }

    public bool CanBuyItem(ShopItem item)
    {
        return _wallet.CurrentCointCount >= item.ItemData.Cost;
    }
}