using System;
using Data;
using UnityEngine;

namespace Managers
{
    public class CurrencyManager : SingletonPersistent<CurrencyManager>
    {
        [SerializeField] private float _currentCoins;
        
        public float CurrentCoins => _currentCoins;

        public event Action<float> OnCurrentCoinsChanged; 
        public event Action<ItemSlotData> OnItemPurchased; 
        public event Action<ItemSlotData> OnItemSold; 
        
        public bool CanBuy(float price)
        {
            var canBuy = _currentCoins >= price;
            Debug.Log(canBuy? "Can Buy Item" : "Cant Buy Item");
            return canBuy;
        }

        public void BuyItem(ItemSlotData itemSlotData)
        {
            Debug.Log($"Buying item for {itemSlotData.ItemPrice} coins");
            _currentCoins -= itemSlotData.ItemPrice;
            OnItemPurchased?.Invoke(itemSlotData);
            OnCurrentCoinsChanged?.Invoke(_currentCoins);
        }

        public void SellItem(ItemSlotData itemSlotData)
        {
            Debug.Log($"Selling item for {itemSlotData.ItemPrice} coins");
            _currentCoins += itemSlotData.ItemPrice;
            OnItemSold?.Invoke(itemSlotData);
            OnCurrentCoinsChanged?.Invoke(_currentCoins);
        }
    }
}