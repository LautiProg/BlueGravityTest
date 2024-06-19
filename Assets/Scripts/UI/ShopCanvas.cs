using System;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ShopCanvas : GameCanvas
    {
        //References
        [SerializeField] private Button _closeCanvasButton;
        [SerializeField] private ShopData _shopData;
        [SerializeField] private ItemSlot _itemSlotPrefab;
        
        //Item Containers
        [SerializeField] private Transform _faceContainer;
        [SerializeField] private Transform _hairContainer;
        [SerializeField] private Transform _clothesContainer;
        [SerializeField] private Transform _pantsContainer;
        [SerializeField] private Transform _footContainer;

        private void Start()
        {
            foreach (var itemSlotData in _shopData.ItemSlotData)
            {
                CreateItemSlot(itemSlotData);
            }
            _closeCanvasButton.onClick.AddListener(CloseCanvas);
        }

        private void CreateItemSlot(ItemSlotData itemSlotData)
        {
            switch (itemSlotData.ItemType)
            {
                case ItemType.Face:
                    Instantiate(_itemSlotPrefab, _faceContainer).InitializeSlot(itemSlotData);
                    break;
                case ItemType.Hair:
                    Instantiate(_itemSlotPrefab, _hairContainer).InitializeSlot(itemSlotData);
                    break;
                case ItemType.Clothes:
                    Instantiate(_itemSlotPrefab, _clothesContainer).InitializeSlot(itemSlotData);
                    break;
                case ItemType.Pants:
                    Instantiate(_itemSlotPrefab, _pantsContainer).InitializeSlot(itemSlotData);
                    break;
                case ItemType.Foot:
                    Instantiate(_itemSlotPrefab, _footContainer).InitializeSlot(itemSlotData);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}