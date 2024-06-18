using UnityEngine;

namespace Shop
{
    [System.Serializable]
    public class ItemSlotData
    {
        public string Name;
        public Sprite ItemIcon;
        public float ItemPrice;
        public string ItemDescription;
        public Sprite ItemSprite;
        public ItemType ItemType;
        public int ID;
    }
}