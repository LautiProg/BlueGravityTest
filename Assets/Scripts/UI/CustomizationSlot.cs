using Data;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CustomizationSlot : MonoBehaviour
    {
        [SerializeField] private Image _itemImage;
        
        private Button _slotButton;
        private ItemSlotData _itemSlotData;
        
        public void InitializeCustomizationSlot(ItemSlotData itemSlotData)
        {
            _itemSlotData = itemSlotData;
            _itemImage.sprite = itemSlotData.ItemIcon;
        }

        private void Awake()
        {
            if (_slotButton == null) _slotButton = GetComponent<Button>();
        }

        private void Start()
        {
            if (_slotButton != null)  _slotButton.onClick.AddListener(HandleSetItem);
        }

        private void HandleSetItem()
        {
            CustomizationManager.Instance.SetItemPiece(_itemSlotData.ItemSprite, _itemSlotData.ItemType);
        }
    }
}