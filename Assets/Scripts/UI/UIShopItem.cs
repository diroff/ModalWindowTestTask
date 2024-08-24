using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIShopItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private TextMeshProUGUI _cost;

    [SerializeField] private Image _icon;

    private ShopItem _shopItem;

    public void SetupItemData(ShopItem shopItem)
    {
        _shopItem = shopItem;

        UpdateItemInfo();
    }

    private void UpdateItemInfo()
    {
        _titleText.text = _shopItem.ItemData.Name;
        _descriptionText.text = _shopItem.ItemData.Description;
        _cost.text = _shopItem.ItemData.Cost.ToString();

        _icon.sprite = _shopItem.ItemData.Sprite;
    }
}