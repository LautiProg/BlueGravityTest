using System;
using Data;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SellCanvas : GameCanvas
    {
        //References
        [SerializeField] private Button _closeCanvasButton;
        [SerializeField] private SellSlot _sellSlotPrefab;
        
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
                    CreateSellSlot(itemSlotData);
                }
            }
            CurrencyManager.Instance.OnItemPurchased += CreateSellSlot;
            _closeCanvasButton.onClick.AddListener(CloseCanvas);
        }

        private void CreateSellSlot(ItemSlotData itemSlotData)
        {
            switch (itemSlotData.ItemType)
            {
                case ItemType.Face:
                    Instantiate(_sellSlotPrefab, _faceContainer).InitializeSlot(itemSlotData);
                    break;
                case ItemType.Hair:
                    Instantiate(_sellSlotPrefab, _hairContainer).InitializeSlot(itemSlotData);
                    break;
                case ItemType.Clothes:
                    Instantiate(_sellSlotPrefab, _clothesContainer).InitializeSlot(itemSlotData);
                    break;
                case ItemType.Pants:
                    Instantiate(_sellSlotPrefab, _pantsContainer).InitializeSlot(itemSlotData);
                    break;
                case ItemType.Foot:
                    Instantiate(_sellSlotPrefab, _footContainer).InitializeSlot(itemSlotData);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}