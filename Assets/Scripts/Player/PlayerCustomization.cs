using System;
using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerCustomization : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _faceRenderer;
        [SerializeField] private SpriteRenderer _hairRenderer;
        [SerializeField] private SpriteRenderer _clothesRenderer;
        [SerializeField] private SpriteRenderer _pantsRenderer;
        [SerializeField] private SpriteRenderer _footRenderer;

        private void Start()
        {
            CustomizationManager.Instance.OnCustomizationChanged += SetCustomization;
        }

        private void SetCustomization(Sprite sprite, ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Face:
                    _faceRenderer.sprite = sprite;
                    break;
                case ItemType.Hair:
                    _hairRenderer.sprite = sprite;
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
                default:
                    throw new ArgumentOutOfRangeException(nameof(itemType), itemType, null);
            }
        }

        private void OnDestroy()
        {
            CustomizationManager.Instance.OnCustomizationChanged -= SetCustomization;
        }
    }
}