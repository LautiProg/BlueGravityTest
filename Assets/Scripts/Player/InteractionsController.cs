using Interact;
using ScriptableObjects;
using UnityEngine;

namespace Player
{
    public class InteractionsController : MonoBehaviour
    {
        private Camera _mainCamera;
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private LayerMask _interactionMask;
        private IInteract _currentInteraction;
        

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Start()
        {
            _inputReader.OnInteractEvent += Interact;
        }

        private void Update()
        {
            CheckForInteractions();
        }

        private void CheckForInteractions()
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, _interactionMask);

            if (hit.collider != null)
            {
                var interact = hit.collider.GetComponent<IInteract>();
                if (interact != null)
                {
                    _currentInteraction = interact;
                    _currentInteraction.Highlight();
                }
                else
                {
                    _currentInteraction?.Hide();
                    _currentInteraction = null; 
                }
            }
            else
            {
                _currentInteraction?.Hide();
                _currentInteraction = null; 
            }
        }
        
        private void Interact()
        {
            _currentInteraction?.Interact();
        }
    }
}