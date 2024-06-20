using System;
using System.Collections.Generic;
using Data;
using Player;
using UnityEngine;

namespace Managers
{
    public class CustomizationManager : SingletonPersistent<CustomizationManager>
    {
        [SerializeField] private CustomizationData _customizationData;
        [SerializeField] private List<ItemSlotData> _itemsObtained;

        public List<ItemSlotData> ItemsObtained => _itemsObtained;
        public event Action<Sprite, ItemType> OnCustomizationChanged;

        private void Start()
        {
            CurrencyManager.Instance.OnItemPurchased += AddPurchasedItem;
            CurrencyManager.Instance.OnItemSold += RemovePurchasedItem;
        }

        private void AddPurchasedItem(ItemSlotData itemSlotData)
        {
            if (_itemsObtained.Contains(itemSlotData)) return;
            _itemsObtained.Add(itemSlotData);
        }

        private void RemovePurchasedItem(ItemSlotData itemSlotData)
        {
            if (!_itemsObtained.Contains(itemSlotData)) return;
            _itemsObtained.Remove(itemSlotData);
        }

        public void SetItemPiece(Sprite sprite, ItemType itemType)
        {
            OnCustomizationChanged?.Invoke(sprite, itemType);
        }

        public void SaveCustomization()
        {
            var customization = FindObjectOfType<PlayerCustomization>().GetCustomization();
            _customizationData.SaveData(customization);
        }

        public Customization LoadCustomization()
        {
            return _customizationData.LoadData();
        }
        
        public bool HasItem(int id)
        {
            return true;
        }
    }
}

public enum ItemType{ Face, Hood, Clothes, Pants, Foot, Weapon}