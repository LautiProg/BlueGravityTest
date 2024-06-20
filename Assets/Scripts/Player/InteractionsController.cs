using Interact;
using Managers;
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

        private void Start()
        {
            _mainCamera = GameManager.Instance.GetMainCamera();
            _inputReader.OnInteractEvent += Interact;
        }

        private void Update()
        {
            CheckForInteractions();
        }

        /// <summary>
        /// Use of Raycast in mouse position to check for interactions
        /// </summary>
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
        
        /// <summary>
        /// Interact with the currentInteraction
        /// </summary>
        private void Interact()
        {
            _currentInteraction?.Interact();
        }
    }
}