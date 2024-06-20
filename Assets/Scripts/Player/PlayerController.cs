using System;
using Managers;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private Camera _mainCamera;
        private NavMeshAgent _navMeshAgent;
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private InteractionsController _interactionsController;
        [SerializeField] private LayerMask _walkLayer;
        [SerializeField] private Vector2 _movementPosition;
        private bool _isMoving;

        private Action _onMoving;

        private void Start()
        {
            _mainCamera = GameManager.Instance.GetMainCamera();
            _navMeshAgent = GetComponent<NavMeshAgent>();

            _navMeshAgent.updateRotation = false;
            _navMeshAgent.updateUpAxis = false;

            _inputReader.OnMovementEvent += MoveToClickPosition;
            _onMoving = delegate { };
        }

        private void Update()
        {
            _onMoving?.Invoke();
        }

        private void MovePlayer()
        {
            _navMeshAgent.SetDestination(_movementPosition);
            if (Vector2.Distance(transform.position, _movementPosition) < 0.1f)
            {
                _onMoving = delegate { };
            }
        }

        private void MoveToClickPosition()
        {
            var worldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _movementPosition = new Vector2(worldPosition.x, worldPosition.y);
            _onMoving = MovePlayer;
        }
    }
}