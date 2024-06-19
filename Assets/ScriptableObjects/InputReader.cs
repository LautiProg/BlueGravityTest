using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "InputReader")]
    public class InputReader : ScriptableObject, GameInput.IGameplayActions
    {
        private GameInput _gameInput;
        
        private void OnEnable()
        {
            if (_gameInput != null) return;
    
            _gameInput = new GameInput();
            Debug.Log("Input System Enabled");
        
            _gameInput.Gameplay.SetCallbacks(this);
            SetGameplay();
        }
        
        public void EnableControls()
        {
            _gameInput.Enable();
        }

        public void DisableControls()
        {
            _gameInput.Disable();
        }

        public void SetGameplay()
        {
            _gameInput.Gameplay.Enable();
            Debug.Log("Setting Gameplay Controls");
        }
        
        public event Action OnMovementEvent;
        public event Action OnInteractEvent;

        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                OnMovementEvent?.Invoke();
            }
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                OnInteractEvent?.Invoke();
            }
        }
    }
}
