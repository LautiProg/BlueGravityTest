using System;
using Data;
using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerCustomization : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _faceRenderer;
        [SerializeField] private SpriteRenderer _hoodRenderer;
        [SerializeField] private SpriteRenderer _clothesRenderer;
        [SerializeField] private SpriteRenderer _pantsRenderer;
        [SerializeField] private SpriteRenderer _footRenderer;
        [SerializeField] private SpriteRenderer _weaponRenderer;

        private void Start()
        {
            CustomizationManager.Instance.OnCustomizationChanged += SetCustomization;
            LoadCustomization();
        }

        private void LoadCustomization()
        {
            var loadedCustomization = CustomizationManager.Instance.LoadCustomization();
            SetCustomization(loadedCustomization.FaceSprite, ItemType.Face);
            SetCustomization(loadedCustomization.HoodSprite, ItemType.Hood);
            SetCustomization(loadedCustomization.ClothesSprite, ItemType.Clothes);
            SetCustomization(loadedCustomization.PantsSprite, ItemType.Pants);
            SetCustomization(loadedCustomization.FootSprite, ItemType.Foot);
            SetCustomization(loadedCustomization.WeaponSprite, ItemType.Weapon);
        }

        private void SetCustomization(Sprite sprite, ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Face:
                    _faceRenderer.sprite = sprite;
                    break;
                case ItemType.Hood:
                    _hoodRenderer.sprite = sprite;
                    break;
                case ItemType.Clothes:
                    _clothesRenderer.sprite = sprite;
                    break;
                case ItemType.Pants:
                    _pantsRenderer.sprite = sprite;
                    break;
                case ItemType.Foot:
                    _footRenderer.sprite = sprite;
                    break;
                case ItemType.Weapon:
                    _weaponRenderer.sprite = sprite;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(itemType), itemType, null);
            }
        }

        public Customization GetCustomization()
        {
            return new Customization
            {
                FaceSprite = _faceRenderer.sprite,
                HoodSprite = _hoodRenderer.sprite,
                ClothesSprite = _clothesRenderer.sprite,
                PantsSprite = _pantsRenderer.sprite,
                FootSprite = _footRenderer.sprite,
                WeaponSprite = _weaponRenderer.sprite
            };
        }
    }
}