using System;
using UnityEngine;

namespace UI
{
    public abstract class GameCanvas : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;
        private bool _isOpened;
        public bool IsOpened => _isOpened;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OpenCanvas()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
            _isOpened = true;
        }

        public void CloseCanvas()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
            _isOpened = false;
        }
    }
}