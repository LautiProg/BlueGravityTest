using System;
using Data;
using UnityEngine;

namespace UI
{
    public class ShopCanvas : GameCanvas
    {
        //References
        [SerializeField] private ShopData _shopData;
        [SerializeField] private ItemSlot _itemSlotPrefab;
        
        //Item Containers
        [SerializeField] private SlotContainer _faceContainer;
        [SerializeField] private SlotContainer _hairContainer;
        [SerializeField] private SlotContainer _clothesContainer;
        [SerializeField] private SlotContainer _pantsContainer;
        [SerializeField] private SlotContainer _footContainer;

        private void Start()
        {
            foreach (var itemSlotData in _shopData.ItemSlotData)
            {
                CreateItemSlot(itemSlotData);
            }
        }

        private void CreateItemSlot(ItemSlotData itemSlotData)
        {
            switch (itemSlotData.ItemType)
            {
                case ItemType.Face:
                    _faceContainer.CreateSlot(_itemSlotPrefab, itemSlotData);
                    break;
                case ItemType.Hair:
                    _hairContainer.CreateSlot(_itemSlotPrefab, itemSlotData);
                    break;
                case ItemType.Clothes:
                    _clothesContainer.CreateSlot(_itemSlotPrefab, itemSlotData);
                    break;
                case ItemType.Pants:
                    _pantsContainer.CreateSlot(_itemSlotPrefab, itemSlotData);
                    break;
                case ItemType.Foot:
                    _footContainer.CreateSlot(_itemSlotPrefab, itemSlotData);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}