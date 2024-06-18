using UnityEngine;

namespace Managers
{
    public class CurrencyManager : SingletonPersistent<CurrencyManager>
    {
        [SerializeField] private float _currentCoins;
        
        public bool CanBuy(float price)
        {
            var canBuy = _currentCoins >= price;
            Debug.Log(canBuy? "Can Buy Item" : "Cant Buy Item");
            return canBuy;
        }

        public void BuyItem(float price)
        {
            Debug.Log($"Buying item for {price} coins");
            _currentCoins -= price;
        }
    }
}