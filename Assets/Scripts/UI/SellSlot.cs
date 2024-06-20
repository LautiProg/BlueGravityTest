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
            ItemImage.rectTransform.localPosition = new Vector2(itemSlotData.Position.x, itemSlotData.Position.y);
            ItemImage.rectTransform.sizeDelta = new Vector2(itemSlotData.WidthHeight.x, itemSlotData.WidthHeight.y);
            _priceText.SetText(itemSlotData.ItemPrice.ToString());
        }

        protected override void HandleOnClick()
        {
            CurrencyManager.Instance.SellItem(_itemSlotData);
            Destroy(gameObject);
        }
    }
}