using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIShopItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private TextMeshProUGUI _cost;

    [SerializeField] private Image _icon;
    [SerializeField] private Button _buyButton;

    public ShopItem ShopItem { get; private set; }

    private void OnEnable()
    {
        if (ShopItem == null)
            return;

        ShopItem.ItemWasBuyed += OnItemWasBuyed;
    }

    private void OnDisable()
    {
        ShopItem.ItemWasBuyed -= OnItemWasBuyed;
    }

    public void SetupItemData(ShopItem shopItem)
    {
        ShopItem = shopItem;
        _buyButton.onClick.AddListener(() => ShopItem.TryToBuyItem());

        UpdateItemInfo();
    }

    public void SetBuyButtonState(bool enabled)
    {
        _buyButton.interactable = enabled;
    }

    private void UpdateItemInfo()
    {
        _titleText.text = ShopItem.ItemData.Name;
        _descriptionText.text = ShopItem.ItemData.Description;
        _cost.text = ShopItem.ItemData.Cost.ToString();

        _icon.sprite = ShopItem.ItemData.Sprite;
    }

    private void OnItemWasBuyed()
    {
        Destroy(gameObject);
    }
}