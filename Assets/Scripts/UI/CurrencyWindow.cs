using System.Globalization;
using Managers;
using TMPro;
using UnityEngine;

namespace UI
{
    public class CurrencyWindow : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinsText;

        private void Start()
        {
            _coinsText.SetText(CurrencyManager.Instance.CurrentCoins.ToString(CultureInfo.InvariantCulture));
            CurrencyManager.Instance.OnCurrentCoinsChanged += UpdateCoinsText;
        }

        private void UpdateCoinsText(float coins)
        {
            _coinsText.SetText(coins.ToString(CultureInfo.InvariantCulture));
        }
    }
}