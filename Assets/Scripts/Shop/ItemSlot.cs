using System.Globalization;
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
        [SerializeField] private GameObject _priceContainer;

        private Sprite _itemSprite;
        private Button _slotButton;
        private float _itemPrice;
        private ItemType _itemType;

        public ItemSlot InitializeItemSlot(ItemSlotData itemSlotData)
        {
            _itemImage.sprite = itemSlotData.ItemIcon;
            _itemPriceText.SetText(itemSlotData.ItemPrice.ToString(CultureInfo.InvariantCulture));
            _itemDescriptionText.SetText(itemSlotData.ItemDescription);
            _itemSprite = itemSlotData.ItemSprite;
            _itemType = itemSlotData.ItemType;
            
            return this;
        }

        private void Awake()
        {
            if (_slotButton == null) _slotButton = GetComponent<Button>();
        }

        private void Start()
        {
            if (_slotButton != null)  _slotButton.onClick.AddListener(HandleBuyItem);
            //if (!CustomizationManager.Instance.HasItem(0)) _slotButton.onClick.AddListener(HandleBuyItem);
            //else _slotButton.onClick.AddListener(HandleEquipItem);
        }

        private void HandleBuyItem()
        {
            if (CurrencyManager.Instance.CanBuy(_itemPrice))
            {
                CurrencyManager.Instance.BuyItem(_itemPrice);
                _priceContainer.SetActive(false);
                _slotButton.onClick.RemoveListener(HandleBuyItem);
                _slotButton.onClick.AddListener(HandleEquipItem);
            }
        }

        private void HandleEquipItem()
        {
            CustomizationManager.Instance.SetItemPiece(_itemSprite, _itemType);
        }
    }
}