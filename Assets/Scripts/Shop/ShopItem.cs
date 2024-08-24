using UnityEngine;
using UnityEngine.Events;

public class ShopItem
{
    public ItemData ItemData { get; private set; }

    public UnityAction ItemWasUpdated;

    public ShopItem(ItemData data)
    {
        ItemData = data;
        ItemWasUpdated?.Invoke();
    }
}