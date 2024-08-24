using TMPro;
using UnityEngine;

public class UICurrentCoinsDisplayer : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TextMeshProUGUI _coinsText;

    private void OnEnable()
    {
        _wallet.CoinCountChanged += OnCoinsCountChanged;
    }

    private void OnDisable()
    {
        _wallet.CoinCountChanged -= OnCoinsCountChanged;
    }

    private void OnCoinsCountChanged(int count)
    {
        _coinsText.text = count.ToString();
    }
}