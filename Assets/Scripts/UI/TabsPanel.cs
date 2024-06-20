using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TabsPanel : MonoBehaviour
    {
        [SerializeField] private Button _customizationTabButton;
        [SerializeField] private Button _quitButton;

        private void Start()
        {
            _customizationTabButton.onClick.AddListener(OpenCustomizationTab);
            _quitButton.onClick.AddListener(QuitGame);
        }

        private void OpenCustomizationTab()
        {
            CanvasManager.Instance.OpenCanvas(CanvasType.Customization);
        }

        private void QuitGame()
        {
            GameManager.Instance.QuitGame();
        }
    }
}