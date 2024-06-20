using System;
using UnityEngine;
using UnityEngine.AI;

namespace Player
{
    public class PlayerMovement
    {
        private readonly NavMeshAgent _navMeshAgent;
        private Vector2 _movementPosition;
        private readonly Camera _mainCamera;
        private readonly Transform _playerTransform;
        private readonly Transform _bodyTransform;
        private Action _onMoving;

        public event Action OnMovement, OnIdle;

        public PlayerMovement(NavMeshAgent navMeshAgent, Camera mainCamera, Transform playerTransform, Transform bodyTransform)
        {
            _navMeshAgent = navMeshAgent;
            _mainCamera = mainCamera;
            _playerTransform = playerTransform;
            _bodyTransform = bodyTransform;
            
            _navMeshAgent.updateRotation = false;
            _navMeshAgent.updateUpAxis = false;
            _onMoving = delegate { };
        }
        
        public void Update()
        {
            _onMoving?.Invoke();
        }
        
        private void MovePlayer()
        {
            _navMeshAgent.SetDestination(_movementPosition);
            
            _bodyTransform.transform.rotation = _movementPosition.x > _playerTransform.position.x ? new Quaternion(0, 0, 0, 0): new Quaternion(0, 180, 0, 0);
            if (Vector2.Distance(_playerTransform.position, _movementPosition) < 0.1f)
            {
                _onMoving = delegate { };
                OnIdle?.Invoke();
            }
        }

        public void MoveToClickPosition()
        {
            var worldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _movementPosition = new Vector2(worldPosition.x, worldPosition.y);
            _onMoving = MovePlayer;
            OnMovement?.Invoke();
        }
    }
}