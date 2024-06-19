using System.Collections.Generic;
using System.Linq;
using Data;
using UnityEngine;

namespace UI
{
    public class SlotContainer : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private List<Slot> _slots = new List<Slot>();

        public void CreateSlot(Slot prefab, ItemSlotData itemSlotData)
        {
            var slot = Instantiate(prefab, _container);
            slot.InitializeSlot(itemSlotData);
            _slots.Add(slot);
        }

        public Slot GetSlot(ItemSlotData itemSlotData)
        {
            return _slots.FirstOrDefault(slot => slot.ItemSlotData == itemSlotData);
        }

        public void DestroySlot(ItemSlotData itemSlotData)
        {
            Destroy(_slots.FirstOrDefault(slot => slot.ItemSlotData == itemSlotData)?.gameObject);
        }
    }
}