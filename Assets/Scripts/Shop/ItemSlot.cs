using System.Globalization;
using Data;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ItemSlot : MonoBehaviour
    {
        [SerializeField] private Image _itemImage;
        [SerializeField] private TextMeshProUGUI _itemPriceText;
        [SerializeField] private TextMeshProUGUI _itemDescriptionText;
        
        private Button _slotButton;
        private ItemSlotData _itemSlotData;

        public float ItemPrice => _itemSlotData.ItemPrice;
        
        public void InitializeItemSlot(ItemSlotData itemSlotData)
        {
            _itemSlotData = itemSlotData;
            _itemImage.sprite = itemSlotData.ItemIcon;
            _itemPriceText.SetText(itemSlotData.ItemPrice.ToString(CultureInfo.InvariantCulture));
            _itemDescriptionText.SetText(itemSlotData.ItemDescription);
        }

        private void Awake()
        {
            if (_slotButton == null) _slotButton = GetComponent<Button>();
        }

        private void Start()
        {
            if (_slotButton != null)  _slotButton.onClick.AddListener(HandleBuyItem);
            //if (!CustomizationManager.Instance.HasItem(0)) _slotButton.onClick.AddListener(HandleBuyItem);
            //else _slotButton.interactable = false;
        }

        private void HandleBuyItem()
        {
            if (!CurrencyManager.Instance.CanBuy(_itemSlotData.ItemPrice)) return;
            
            CurrencyManager.Instance.BuyItem(_itemSlotData);
            _slotButton.interactable = false;
        }
    }
}