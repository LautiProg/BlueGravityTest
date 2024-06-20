using UnityEngine;
using UnityEngine.Serialization;

namespace Data
{
    [CreateAssetMenu(menuName = "CustomizationData")]
    public class CustomizationData : ScriptableObject
    {
        [SerializeField] public Sprite FaceData;
        [SerializeField] public Sprite HoodData;
        [SerializeField] public Sprite ClothesData;
        [SerializeField] public Sprite PantsData;
        [SerializeField] public Sprite FootData;
        [SerializeField] public Sprite WeaponData;

        public void SaveData(Customization customization)
        {
            FaceData = customization.FaceSprite;
            HoodData = customization.HoodSprite;
            ClothesData = customization.ClothesSprite;
            PantsData = customization.PantsSprite;
            FootData = customization.FootSprite;
            WeaponData = customization.WeaponSprite;
        }

        public Customization LoadData()
        {
            return new Customization
            {
                FaceSprite = FaceData,
                HoodSprite = HoodData,
                ClothesSprite = ClothesData,
                PantsSprite = PantsData,
                FootSprite = FootData,
                WeaponSprite = WeaponData,
            };
        }
    }

    public struct Customization
    {
        public Sprite FaceSprite;
        public Sprite HoodSprite;
        public Sprite ClothesSprite;
        public Sprite PantsSprite;
        public Sprite FootSprite;
        public Sprite WeaponSprite;
    }
}