using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIShopItem : MonoBehaviour
{
    [Header("Text fields")]
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private TextMeshProUGUI _cost;

    [Header("Other elements")]
    [SerializeField] private Image _buyButtonBackground;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _buyButton;

    [Header("Disabled button settings")]
    [SerializeField] private Color _defaultCostColor;
    [SerializeField] private Color _disabledButtonCostColor;

    [SerializeField] private Sprite _defaultButtonSprite;
    [SerializeField] private Sprite _disabledButtonSprite;

    public ShopItem ShopItem { get; private set; }

    private void Awake()
    {
        _defaultCostColor = _cost.color;
        _defaultButtonSprite = _buyButtonBackground.sprite;
    }

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

        _cost.color = enabled? _defaultCostColor: _disabledButtonCostColor;
        _buyButtonBackground.sprite = enabled? _defaultButtonSprite: _disabledButtonSprite;
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