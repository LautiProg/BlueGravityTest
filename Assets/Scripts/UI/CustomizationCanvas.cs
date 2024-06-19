using System;
using Data;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CustomizationCanvas : MonoBehaviour
    {
        //References
        [SerializeField] private Button _saveCustomizationButton;
        [SerializeField] private Button _closeCanvasButton;
        [SerializeField] private CustomizationSlot _customizationSlotPrefab;
        
        //Item Containters
        [SerializeField] private Transform _faceContainer;
        [SerializeField] private Transform _hairContainer;
        [SerializeField] private Transform _clothesContainer;
        [SerializeField] private Transform _pantsContainer;
        [SerializeField] private Transform _footContainer;

        private void Start()
        {
            foreach (var itemSlotData in CustomizationManager.Instance.ItemsObtained)
            {
                CreateCustomizationSlot(itemSlotData);
            }

            CurrencyManager.Instance.OnItemPurchased += CreateCustomizationSlot;
            _closeCanvasButton.onClick.AddListener(CloseCanvas);
        }
        
        private void CloseCanvas()
        {
            GetComponent<CanvasGroup>().alpha = 0;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        public void CreateCustomizationSlot(ItemSlotData itemSlotData)
        {
            switch (itemSlotData.ItemType)
            {
                case ItemType.Face:
                    Instantiate(_customizationSlotPrefab, _faceContainer).InitializeCustomizationSlot(itemSlotData);
                    break;
                case ItemType.Hair:
                    Instantiate(_customizationSlotPrefab, _hairContainer).InitializeCustomizationSlot(itemSlotData);
                    break;
                case ItemType.Clothes:
                    Instantiate(_customizationSlotPrefab, _clothesContainer).InitializeCustomizationSlot(itemSlotData);
                    break;
                case ItemType.Pants:
                    Instantiate(_customizationSlotPrefab, _pantsContainer).InitializeCustomizationSlot(itemSlotData);
                    break;
                case ItemType.Foot:
                    Instantiate(_customizationSlotPrefab, _footContainer).InitializeCustomizationSlot(itemSlotData);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}