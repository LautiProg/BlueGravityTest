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

        private void Start()
        {
            _mainCamera = Camera.main;
            _navMeshAgent = GetComponent<NavMeshAgent>();

            _navMeshAgent.updateRotation = false;
            _navMeshAgent.updateUpAxis = false;

            _inputReader.OnMovementEvent += MoveToClickPosition;
        }

        private void MoveToClickPosition()
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.GetRayIntersection(ray);
            if (hit.collider != null)
            {
                _navMeshAgent.SetDestination(hit.point);
            }
        }
    }
}