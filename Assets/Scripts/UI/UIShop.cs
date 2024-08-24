using UnityEngine;

public class UIShop : MonoBehaviour
{
    [SerializeField] private Transform _gridPlacement;
    [SerializeField] private UIShopItem _slotPrefab;

    [SerializeField] private Shop _shop;

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
        }
    }
}