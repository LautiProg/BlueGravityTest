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
                case ItemType.Hood:
                    _hoodContainer.CreateSlot(_itemSlotPrefab, itemSlotData);
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
                case ItemType.Weapon:
                    _weaponContainer.CreateSlot(_itemSlotPrefab, itemSlotData);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}