using System.Globalization;
using Data;
using Managers;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ItemSlot : Slot
    {
        [SerializeField] private TextMeshProUGUI _itemPriceText;
        
        public override void InitializeSlot(ItemSlotData itemSlotData)
        {
            _itemSlotData = itemSlotData;
            ItemImage.sprite = itemSlotData.ItemIcon;
            _itemPriceText.SetText(itemSlotData.ItemPrice.ToString(CultureInfo.InvariantCulture));
        }

        protected override void HandleOnClick()
        {
            if (!CurrencyManager.Instance.CanBuy(_itemSlotData.ItemPrice)) return;
            
            CurrencyManager.Instance.BuyItem(_itemSlotData);
            SlotButton.interactable = false;
        }
    }
}