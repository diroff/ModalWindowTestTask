using System.Collections.Generic;
using UnityEngine;

public class UIShop : MonoBehaviour
{
    [SerializeField] private Transform _gridPlacement;
    [SerializeField] private UIShopItem _slotPrefab;

    [SerializeField] private Shop _shop;

    private List<UIShopItem> _uiItems = new List<UIShopItem>();

    private void OnEnable()
    {
        _shop.ShopWasUpdated += OnItemWasBuyed;
    }

    private void OnDisable()
    {
        _shop.ShopWasUpdated -= OnItemWasBuyed;
    }

    private void Start()
    {
        CreateShopGrid();
    }

    private void CreateShopGrid()
    {
        foreach (var item in _shop.CurrentItemsData)
        {
            var uiShopItem = Instantiate(_slotPrefab, _gridPlacement);
            uiShopItem.SetupItemData(item);

            _uiItems.Add(uiShopItem);
        }
    }

    private void OnItemWasBuyed()
    {
        foreach(var uiItem in _uiItems)
        {
            if (uiItem == null)
                continue;
            
            uiItem.SetBuyButtonState(_shop.CanBuyItem(uiItem.ShopItem));
        }
    }
}