using Data;
using Managers;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public abstract class Slot : MonoBehaviour
    {
        [FormerlySerializedAs("_itemImage")] [SerializeField] protected Image ItemImage;
        
        protected Button SlotButton;
        protected ItemSlotData _itemSlotData;
        public ItemSlotData ItemSlotData => _itemSlotData;

        private void Awake()
        {
            if (SlotButton == null) SlotButton = GetComponent<Button>();
        }

        private void Start()
        {
            if (SlotButton != null)  SlotButton.onClick.AddListener(HandleOnClick);
        }

        public abstract void InitializeSlot(ItemSlotData itemSlotData);

        protected abstract void HandleOnClick();
    }
}
