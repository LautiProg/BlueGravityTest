using System;
using System.Collections.Generic;
using Shop;
using UnityEngine;

namespace Managers
{
    public class CustomizationManager : SingletonPersistent<CustomizationManager>
    { 
        public event Action<Sprite, ItemType> OnCustomizationChanged;
        [SerializeField] private List<ItemSlotData> _itemsObtained;

        private void Start()
        {
            CurrencyManager.Instance.OnItemPurchased += AddPurchasedItem;
        }

        private void AddPurchasedItem(ItemSlotData itemSlotData)
        {
            if (_itemsObtained.Contains(itemSlotData)) return;
            _itemsObtained.Add(itemSlotData);
        }

        public void SetItemPiece(Sprite sprite, ItemType itemType)
        {
            OnCustomizationChanged?.Invoke(sprite, itemType);
        }
        
        public bool HasItem(int id)
        {
            return true;
        }
    }
}

public enum ItemType{ Face, Hair, Clothes, Pants, Foot}