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
        [SerializeField] private Button _closeCanvasButton;
        [SerializeField] private CustomizationSlot _customizationSlotPrefab;
        
        //Item Containers
        [SerializeField] private Transform _faceContainer;
        [SerializeField] private Transform _hairContainer;
        [SerializeField] private Transform _clothesContainer;
        [SerializeField] private Transform _pantsContainer;
        [SerializeField] private Transform _footContainer;

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
            _closeCanvasButton.onClick.AddListener(CloseCanvas);
        }

        private void CreateCustomizationSlot(ItemSlotData itemSlotData)
        {
            switch (itemSlotData.ItemType)
            {
                case ItemType.Face:
                    Instantiate(_customizationSlotPrefab, _faceContainer).InitializeSlot(itemSlotData);
                    break;
                case ItemType.Hair:
                    Instantiate(_customizationSlotPrefab, _hairContainer).InitializeSlot(itemSlotData);
                    break;
                case ItemType.Clothes:
                    Instantiate(_customizationSlotPrefab, _clothesContainer).InitializeSlot(itemSlotData);
                    break;
                case ItemType.Pants:
                    Instantiate(_customizationSlotPrefab, _pantsContainer).InitializeSlot(itemSlotData);
                    break;
                case ItemType.Foot:
                    Instantiate(_customizationSlotPrefab, _footContainer).InitializeSlot(itemSlotData);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void RemoveCustomizationSlot(ItemSlotData itemSlotData)
        {
            var container = itemSlotData.ItemType switch
            {
                ItemType.Face => _faceContainer.transform,
                ItemType.Hair => _hairContainer.transform,
                ItemType.Clothes => _clothesContainer.transform,
                ItemType.Pants => _pantsContainer.transform,
                ItemType.Foot => _footContainer.transform,
                _ => throw new ArgumentOutOfRangeException()
            };

            foreach (CustomizationSlot item in container)
            {
                if (item.ItemSlotData == itemSlotData)
                {
                    Destroy(item.gameObject);
                }
            }
        }
    }
}