using System;
using UI;
using UnityEngine;

namespace Interact
{
    [RequireComponent(typeof(Collider2D))]
    public class ShopInteract : MonoBehaviour, IInteract
    {
        [SerializeField] private GameObject _highlight;
        [SerializeField] private PopUp _buyPopUp;
        [SerializeField] private PopUp _sellPopUp;

        private void Start()
        {
            _buyPopUp.OnClick += OpenShopCanvas;
            _sellPopUp.OnClick += OpenSellCanvas;
        }

        private void OpenShopCanvas()
        {
            CanvasManager.Instance.OpenCanvas(CanvasType.Shop);
        }
        
        private void OpenSellCanvas()
        {
            CanvasManager.Instance.OpenCanvas(CanvasType.Sell);
        }

        /// <summary>
        /// Show the pop ups
        /// </summary>
        public void Interact()
        {
            _buyPopUp.ShowPopUp();
            _sellPopUp.ShowPopUp();
        }
        
        public void Highlight()
        {
            _highlight.SetActive(true);
        }
        
        public void Hide()
        {
            _highlight.SetActive(false);
        }
    }
}
