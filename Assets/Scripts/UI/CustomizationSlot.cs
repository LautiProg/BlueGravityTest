using Data;
using Managers;

namespace UI
{
    public class CustomizationSlot : Slot
    {
        public override void InitializeSlot(ItemSlotData itemSlotData)
        {
            _itemSlotData = itemSlotData;
            ItemImage.sprite = itemSlotData.ItemIcon;
        }

        protected override void HandleOnClick()
        {
            CustomizationManager.Instance.SetItemPiece(_itemSlotData.ItemSprite, _itemSlotData.ItemType);
        }
    }
}