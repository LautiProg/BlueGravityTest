using System;
using Managers;
using UnityEngine;

namespace UI
{
    public class CanvasManager : SingletonPersistent<CanvasManager>
    {
        [SerializeField] private ShopCanvas _shopCanvas;
        [SerializeField] private CustomizationCanvas _customizationCanvas;
        private GameCanvas _currentCanvas;

        private void Start()
        {
            _shopCanvas.CloseCanvas();
            _customizationCanvas.CloseCanvas();
        }

        public void OpenCanvas(CanvasType canvasType)
        {
            if (_currentCanvas != null && _currentCanvas.IsOpened) _currentCanvas.CloseCanvas();
            _currentCanvas = GetCanvas(canvasType);
            _currentCanvas.OpenCanvas();
        }

        private GameCanvas GetCanvas(CanvasType canvasType)
        {
            return canvasType switch
            {
                CanvasType.Shop => _shopCanvas,
                CanvasType.Customization => _customizationCanvas,
                _ => throw new ArgumentOutOfRangeException(nameof(canvasType), canvasType, null)
            };
        }
    }
    
    public enum CanvasType
    {
        Shop, Customization
    }
}