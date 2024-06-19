using UI;
using UnityEngine;

namespace Interact
{
    [RequireComponent(typeof(Collider2D))]
    public class ShopInteract : MonoBehaviour, IInteract
    {
        [SerializeField] private GameObject _highlight;
    
        public void Interact()
        {
            CanvasManager.Instance.OpenCanvas(CanvasType.Shop);
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
