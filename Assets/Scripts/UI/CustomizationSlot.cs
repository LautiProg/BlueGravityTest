using Data;
using Managers;
using UnityEngine;

namespace UI
{
    public class CustomizationSlot : Slot
    {
        public override void InitializeSlot(ItemSlotData itemSlotData)
        {
            _itemSlotData = itemSlotData;
            ItemImage.sprite = itemSlotData.ItemIcon;
            ItemImage.rectTransform.localPosition = new Vector2(itemSlotData.Position.x, itemSlotData.Position.y);
            ItemImage.rectTransform.sizeDelta = new Vector2(itemSlotData.WidthHeight.x, itemSlotData.WidthHeight.y);
        }

        protected override void HandleOnClick()
        {
            CustomizationManager.Instance.SetItemPiece(_itemSlotData.ItemSprite, _itemSlotData.ItemType);
        }
    }
}