using UnityEngine;
using UnityEngine.Events;

public class ShopItem
{
    public ItemData ItemData { get; private set; }

    public UnityAction ItemWasUpdated;
    public UnityAction<ShopItem> ItemTryiedToBuy;
    public UnityAction ItemWasBuyed;

    public ShopItem(ItemData data)
    {
        ItemData = data;
        ItemWasUpdated?.Invoke();
    }

    public void TryToBuyItem()
    {
        ItemTryiedToBuy?.Invoke(this);
    }

    public void BuyItem()
    {
        ItemWasBuyed?.Invoke();
    }
}