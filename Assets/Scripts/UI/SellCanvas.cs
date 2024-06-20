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
        [SerializeField] private SellSlot _sellSlotPrefab;
        
        //Buttons
        [Header("Buttons")]
        [SerializeField] private Button _faceButton;
        [SerializeField] private Button _hoodButton;
        [SerializeField] private Button _clothesButton;
        [SerializeField] private Button _pantsButton;
        [SerializeField] private Button _footButton;
        [SerializeField] private Button _weaponButton;
        
        //Item Containers
        [Header("Containers")]
        [SerializeField] private SlotContainer _faceContainer;
        [SerializeField] private SlotContainer _hoodContainer;
        [SerializeField] private SlotContainer _clothesContainer;
        [SerializeField] private SlotContainer _pantsContainer;
        [SerializeField] private SlotContainer _footContainer;
        [SerializeField] private SlotContainer _weaponContainer;
        
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
            
            _currentContainer = _faceContainer;

            _faceButton.onClick.AddListener(() => OpenCanvas(ItemType.Face));
            _hoodButton.onClick.AddListener(() => OpenCanvas(ItemType.Hood));
            _clothesButton.onClick.AddListener(() => OpenCanvas(ItemType.Clothes));
            _pantsButton.onClick.AddListener(() => OpenCanvas(ItemType.Pants));
            _footButton.onClick.AddListener(() => OpenCanvas(ItemType.Foot));
            _weaponButton.onClick.AddListener(() => OpenCanvas(ItemType.Weapon));
        }
        
        public void OpenCanvas(ItemType itemType)
        {
            if (_currentContainer != null && _currentContainer.isActiveAndEnabled) _currentContainer.gameObject.SetActive(false);
            _currentContainer = GetSlotContainer(itemType);
            _currentContainer.gameObject.SetActive(true);
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
        
        private SlotContainer GetSlotContainer(ItemType itemType)
        {
            return itemType switch
            {
                ItemType.Face => _faceContainer,
                ItemType.Hood => _hoodContainer,
                ItemType.Clothes => _clothesContainer,
                ItemType.Pants => _pantsContainer,
                ItemType.Foot => _footContainer,
                ItemType.Weapon => _weaponContainer,
                _ => throw new ArgumentOutOfRangeException(nameof(itemType), itemType, null)
            };
        }
    }
}