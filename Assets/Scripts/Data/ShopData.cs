using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "ShopData")]
    public class ShopData : ScriptableObject
    {
        public ItemSlotData[] ItemSlotData;
    }
}