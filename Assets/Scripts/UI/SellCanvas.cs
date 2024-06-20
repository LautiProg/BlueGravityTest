using System;
using Data;
using Managers;
using UnityEngine;

namespace UI
{
    public class SellCanvas : GameCanvas
    {
        //References
        [SerializeField] private SellSlot _sellSlotPrefab;
        
        private SlotContainer _currentContainer;

        private void Start()
        {
            if (CustomizationManager.Instance.ItemsObtained.Count > 0 && CustomizationManager.Instance.ItemsObtained != null)
            {
                foreach (var itemSlotData in CustomizationManager.Instance.ItemsObtained)
                {
                    CreateSellSlot(itemSlotData);
                }
            }
            CurrencyManager.Instance.OnItemPurchased += CreateSellSlot;
        }

        private void CreateSellSlot(ItemSlotData itemSlotData)
        {
            switch (itemSlotData.ItemType)
            {
                case ItemType.Face:
                    _faceContainer.CreateSlot(_sellSlotPrefab, itemSlotData);
                    break;
                case ItemType.Hood:
                    _hoodContainer.CreateSlot(_sellSlotPrefab, itemSlotData);
                    break;
                case ItemType.Clothes:
                    _clothesContainer.CreateSlot(_sellSlotPrefab, itemSlotData);
                    break;
                case ItemType.Pants:
                    _pantsContainer.CreateSlot(_sellSlotPrefab, itemSlotData);
                    break;
                case ItemType.Foot:
                    _footContainer.CreateSlot(_sellSlotPrefab, itemSlotData);
                    break;
                case ItemType.Weapon:
                    _weaponContainer.CreateSlot(_sellSlotPrefab, itemSlotData);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}