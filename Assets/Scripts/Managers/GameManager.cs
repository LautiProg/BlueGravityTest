using UnityEngine;

namespace Managers
{
    public class GameManager : SingletonPersistent<GameManager>
    {
        [SerializeField] private Camera _mainCamera;

        public Camera GetMainCamera()
        {
            return _mainCamera;
        }
    }
}