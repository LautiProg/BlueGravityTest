using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TabsPanel : MonoBehaviour
    {
        [SerializeField] private Button _customizationTabButton;
        [SerializeField] private Button _shopTabButton;

        private void Start()
        {
            _customizationTabButton.onClick.AddListener(OpenCustomizationTab);
            _shopTabButton.onClick.AddListener(OpenShopTab);
        }

        private void OpenCustomizationTab()
        {
            CanvasManager.Instance.OpenCanvas(CanvasType.Customization);
        }

        private void OpenShopTab()
        {
            CanvasManager.Instance.OpenCanvas(CanvasType.Shop);
        }
    }
}