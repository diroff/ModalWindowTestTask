using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [Min(0)][SerializeField] private int _startCoinCount;

    public int CurrentCointCount { get; private set; }

    public UnityAction<int> CoinCountChanged;

    private void Awake()
    {
        AddCoins(_startCoinCount);
    }

    public void AddCoins(int coinCount)
    {
        if (coinCount <= 0)
            return;

        CurrentCointCount += coinCount;
        CoinCountChanged?.Invoke(CurrentCointCount);
    }

    public bool TryToSpendCoins(int coinCount)
    {
        if(CurrentCointCount < coinCount || coinCount < 0)
            return false;

        SpendCoins(coinCount);
        return true;
    }

    private void SpendCoins(int coinCount)
    {
        CurrentCointCount -= coinCount;
        CoinCountChanged?.Invoke(CurrentCointCount);
    }
}