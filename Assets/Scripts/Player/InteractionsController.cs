using Interact;
using ScriptableObjects;
using UnityEngine;

namespace Player
{
    public class InteractionsController : MonoBehaviour
    {
        private Camera _mainCamera;
        [SerializeField] private InputReader _inputReader;
        private IInteract _currentInteraction;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            CheckForInteractions();
        }

        private void CheckForInteractions()
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        }
        
        private void Interact()
        {
            _currentInteraction?.Interact();
        }
    }
}