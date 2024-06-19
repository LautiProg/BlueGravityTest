using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TabsPanel : MonoBehaviour
    {
        [SerializeField] private Button _customizationTabButton;

        private void Start()
        {
            _customizationTabButton.onClick.AddListener(OpenCustomizationTab);
        }

        private void OpenCustomizationTab()
        {
            
        }
    }
}