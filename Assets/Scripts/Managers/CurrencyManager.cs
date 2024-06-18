using UnityEngine;

namespace Managers
{
    public class CurrencyManager : SingletonPersistent<CurrencyManager>
    {
        [SerializeField] private float _currentCoins;
        
        public bool CanBuy(float price)
        {
            return _currentCoins >= price;
        }
    }
}
