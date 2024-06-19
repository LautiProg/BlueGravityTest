using Data;
using Managers;

namespace UI
{
    public class SellSlot : Slot
    {
        public override void InitializeSlot(ItemSlotData itemSlotData)
        {
            _itemSlotData = itemSlotData;
            ItemImage.sprite = itemSlotData.ItemIcon;
        }

        protected override void HandleOnClick()
        {
            CurrencyManager.Instance.SellItem(_itemSlotData);
            Destroy(gameObject);
        }
    }
}