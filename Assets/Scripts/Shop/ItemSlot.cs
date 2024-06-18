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

        private Sprite _itemSprite;
        private Button _slotButton;
        private float _itemPrice;

        public ItemSlot InitializeItemSlot(ItemSlotData itemSlotData)
        {
            _itemImage.sprite = itemSlotData.ItemIcon;
            _itemPriceText.SetText(itemSlotData.ItemPrice.ToString(CultureInfo.InvariantCulture));
            _itemDescriptionText.SetText(itemSlotData.ItemDescription);
            _itemSprite = itemSlotData.ItemSprite;
            return this;
        }

        private void Awake()
        {
            if (_slotButton == null) _slotButton = GetComponent<Button>();
        }

        private void Start()
        {
            if (_slotButton == null) _slotButton.onClick.AddListener(HandleOnClick);
        }

        private void HandleOnClick()
        {
            if (CurrencyManager.Instance.CanBuy(_itemPrice))
            {
                //CustomizationManager.SetItemPiece(_itemSprite);
            }
            else
            {
                Debug.Log("Cant buy, not enough money");
            }
        }
    }
}