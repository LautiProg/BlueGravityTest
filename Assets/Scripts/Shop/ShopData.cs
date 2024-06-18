using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(menuName = "ShopData")]
    public class ShopData : ScriptableObject
    {
        public ItemSlotData[] ItemSlotData;
    }
}