using System;
using UnityEngine;

namespace Managers
{
    public class CustomizationManager : SingletonPersistent<CustomizationManager>
    { 
        public event Action<Sprite, ItemType> OnCustomizationChanged; 

        public void SetItemPiece(Sprite sprite, ItemType itemType)
        {
            OnCustomizationChanged?.Invoke(sprite, itemType);
        }
        
        public bool HasItem(int id)
        {
            return true;
        }
    }
}

public enum ItemType{ Face, Hair, Clothes, Pants, Foot}