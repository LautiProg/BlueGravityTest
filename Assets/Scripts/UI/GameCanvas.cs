using UnityEngine;
using UnityEngine.UI;
using System;

namespace UI
{
    public abstract class GameCanvas : MonoBehaviour
    {
        [SerializeField] private Button _closeCanvasButton;
        private CanvasGroup _canvasGroup;
        private bool _isOpened;
        public bool IsOpened => _isOpened;
        
        //Buttons
        [Header("Buttons")]
        [SerializeField] private Button _faceButton;
        [SerializeField] private Button _hoodButton;
        [SerializeField] private Button _clothesButton;
        [SerializeField] private Button _pantsButton;
        [SerializeField] private Button _footButton;
        [SerializeField] private Button _weaponButton;
        
        //Item Containers
        [Header("Containers")]
        [SerializeField] protected SlotContainer _faceContainer;
        [SerializeField] protected SlotContainer _hoodContainer;
        [SerializeField] protected SlotContainer _clothesContainer;
        [SerializeField] protected SlotContainer _pantsContainer;
        [SerializeField] protected SlotContainer _footContainer;
        [SerializeField] protected SlotContainer _weaponContainer;

        private SlotContainer _currentContainer;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _closeCanvasButton.onClick.AddListener(CloseCanvas);
            
            _currentContainer = _faceContainer;
            
            _faceButton.onClick.AddListener(() => OpenContainer(ItemType.Face));
            _hoodButton.onClick.AddListener(() => OpenContainer(ItemType.Hood));
            _clothesButton.onClick.AddListener(() => OpenContainer(ItemType.Clothes));
            _pantsButton.onClick.AddListener(() => OpenContainer(ItemType.Pants));
            _footButton.onClick.AddListener(() => OpenContainer(ItemType.Foot));
            _weaponButton.onClick.AddListener(() => OpenContainer(ItemType.Weapon));
        }

        private void OpenContainer(ItemType itemType)
        {
            if (_currentContainer != null && _currentContainer.isActiveAndEnabled) _currentContainer.gameObject.SetActive(false);
            _currentContainer = GetSlotContainer(itemType);
            _currentContainer.gameObject.SetActive(true);
        }
        
        private SlotContainer GetSlotContainer(ItemType itemType)
        {
            return itemType switch
            {
                ItemType.Face => _faceContainer,
                ItemType.Hood => _hoodContainer,
                ItemType.Clothes => _clothesContainer,
                ItemType.Pants => _pantsContainer,
                ItemType.Foot => _footContainer,
                ItemType.Weapon => _weaponContainer,
                _ => throw new ArgumentOutOfRangeException(nameof(itemType), itemType, null)
            };
        }

        public void OpenCanvas()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
            _isOpened = true;
        }

        public void CloseCanvas()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
            _isOpened = false;
        }
    }
}