using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TabsPanel : MonoBehaviour
    {
        [SerializeField] private Button _customizationTabButton;
        [SerializeField] private Button _shopTabButton;
        [SerializeField] private Button _sellTabButton;

        private void Start()
        {
            _customizationTabButton.onClick.AddListener(OpenCustomizationTab);
            _shopTabButton.onClick.AddListener(OpenShopTab);
            _sellTabButton.onClick.AddListener(OpenSellTab);
        }

        private void OpenCustomizationTab()
        {
            CanvasManager.Instance.OpenCanvas(CanvasType.Customization);
        }

        private void OpenShopTab()
        {
            CanvasManager.Instance.OpenCanvas(CanvasType.Shop);
        }

        private void OpenSellTab()
        {
            CanvasManager.Instance.OpenCanvas(CanvasType.Sell);
        }
    }
}