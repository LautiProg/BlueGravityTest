using Data;
using Managers;
using TMPro;
using UnityEngine;

namespace UI
{
    public class SellSlot : Slot
    {
        [SerializeField] private TextMeshProUGUI _priceText;
        public override void InitializeSlot(ItemSlotData itemSlotData)
        {
            _itemSlotData = itemSlotData;
            ItemImage.sprite = itemSlotData.ItemIcon;
            _priceText.SetText(itemSlotData.ItemPrice.ToString());
        }

        protected override void HandleOnClick()
        {
            CurrencyManager.Instance.SellItem(_itemSlotData);
            Destroy(gameObject);
        }
    }
}