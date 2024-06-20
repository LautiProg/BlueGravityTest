using System;
using Data;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CustomizationCanvas : GameCanvas
    {
        //References
        [SerializeField] private Button _saveCustomizationButton;
        [SerializeField] private CustomizationSlot _customizationSlotPrefab;
        
        private SlotContainer _currentContainer;

        private void Start()
        {
            if (CustomizationManager.Instance.ItemsObtained.Count > 0 && CustomizationManager.Instance.ItemsObtained != null)
            {
                foreach (var itemSlotData in CustomizationManager.Instance.ItemsObtained)
                {
                    CreateCustomizationSlot(itemSlotData);
                }
            }

            CurrencyManager.Instance.OnItemPurchased += CreateCustomizationSlot;
            CurrencyManager.Instance.OnItemSold += RemoveCustomizationSlot;
        }

        private void CreateCustomizationSlot(ItemSlotData itemSlotData)
        {
            switch (itemSlotData.ItemType)
            {
                case ItemType.Face:
                    _faceContainer.CreateSlot(_customizationSlotPrefab, itemSlotData);
                    break;
                case ItemType.Hood:
                    _hoodContainer.CreateSlot(_customizationSlotPrefab, itemSlotData);
                    break;
                case ItemType.Clothes:
                    _clothesContainer.CreateSlot(_customizationSlotPrefab, itemSlotData);
                    break;
                case ItemType.Pants:
                    _pantsContainer.CreateSlot(_customizationSlotPrefab, itemSlotData);
                    break;
                case ItemType.Foot:
                    _footContainer.CreateSlot(_customizationSlotPrefab, itemSlotData);
                    break;
                case ItemType.Weapon:
                    _weaponContainer.CreateSlot(_customizationSlotPrefab, itemSlotData);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void RemoveCustomizationSlot(ItemSlotData itemSlotData)
        {
            var container = itemSlotData.ItemType switch
            {
                ItemType.Face => _faceContainer,
                ItemType.Hood => _hoodContainer,
                ItemType.Clothes => _clothesContainer,
                ItemType.Pants => _pantsContainer,
                ItemType.Foot => _footContainer,
                ItemType.Weapon => _weaponContainer,
                _ => throw new ArgumentOutOfRangeException()
            };
            
            if (container.GetSlot(itemSlotData)) container.DestroySlot(itemSlotData);
        }
    }
}