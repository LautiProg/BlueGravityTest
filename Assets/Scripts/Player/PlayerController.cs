using Managers;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private Transform _bodyTransform;
        
        private Camera _mainCamera;
        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        
        private PlayerMovement _playerMovement;
        private PlayerAnimationController _playerAnimationController;

        private void Start()
        {
            _mainCamera = GameManager.Instance.GetMainCamera();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponentInChildren<Animator>();
            
            _playerMovement = new PlayerMovement(_navMeshAgent, _mainCamera, transform, _bodyTransform);
            _playerAnimationController = new PlayerAnimationController(_animator, _playerMovement);

            SetUpInputActions();
        }

        private void SetUpInputActions()
        {
            _inputReader.OnMovementEvent += _playerMovement.MoveToClickPosition;
        }

        private void Update()
        {
            _playerMovement.Update();
        }
    }
}