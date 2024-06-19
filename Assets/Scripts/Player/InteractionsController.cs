using System;
using System.Collections.Generic;
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
        private List<IInteract> _interactsInRange;

        private Action _onInteractionsInRange;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _onInteractionsInRange = delegate { };
        }

        private void Start()
        {
            _inputReader.OnInteractEvent += Interact;
        }

        // private void OnTriggerEnter2D(Collider2D other)
        // {
        //     var interact = other.GetComponent<IInteract>();
        //     if (interact == null || _interactsInRange.Contains(interact)) return;
        //     
        //     if (_interactsInRange.Count <= 0) _onInteractionsInRange = CheckForInteractions;
        //     _interactsInRange.Add(interact);
        // }
        //
        // private void OnTriggerExit2D(Collider2D other)
        // {
        //     var interact = other.GetComponent<IInteract>();
        //     if (interact != null && _interactsInRange.Contains(interact))
        //     {
        //         _interactsInRange.Remove(interact);
        //         if (_interactsInRange.Count <= 0) _onInteractionsInRange = delegate { };
        //     }
        // }

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