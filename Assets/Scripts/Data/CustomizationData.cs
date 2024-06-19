using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "CustomizationData")]
    public class CustomizationData : ScriptableObject
    {
        [SerializeField] public Sprite FaceData;
        [SerializeField] public Sprite HairData;
        [SerializeField] public Sprite ClothesData;
        [SerializeField] public Sprite PantsData;
        [SerializeField] public Sprite FootData;

        public void SaveData(Customization customization)
        {
            FaceData = customization.FaceSprite;
            HairData = customization.HairSprite;
            ClothesData = customization.ClothesSprite;
            PantsData = customization.PantsSprite;
            FootData = customization.FootSprite;
        }

        public Customization LoadData()
        {
            return new Customization
            {
                FaceSprite = FaceData,
                HairSprite = HairData,
                ClothesSprite = ClothesData,
                PantsSprite = PantsData,
                FootSprite = FootData,
            };
        }
    }

    public struct Customization
    {
        public Sprite FaceSprite;
        public Sprite HairSprite;
        public Sprite ClothesSprite;
        public Sprite PantsSprite;
        public Sprite FootSprite;
    }
}