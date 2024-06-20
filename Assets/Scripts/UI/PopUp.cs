using System;
using System.Collections;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PopUp : MonoBehaviour
    {
        [SerializeField] private float _animTime = 1f;
        public event Action OnClick;
        private Button _button;

        private void Awake()
        {
            _button = GetComponentInChildren<Button>();
        }

        private void Start()
        {
            GetComponent<Canvas>().worldCamera = GameManager.Instance.GetMainCamera();
            _button.onClick.AddListener(HandleOnClick);
        }

        private void HandleOnClick()
        {
            OnClick?.Invoke();
        }

        public void ShowPopUp()
        {
            StartCoroutine(PopUpAnimation(true));
        }

        public void HidePopUp()
        {
            StartCoroutine(PopUpAnimation(false));
        }

        private IEnumerator PopUpAnimation(bool show)
        {
            var elapsedTime = 0f;
            var targetScale = show ? Vector3.one : Vector3.zero;
            while (elapsedTime < _animTime)
            {
                elapsedTime += Time.deltaTime;
                transform.localScale = Vector3.Lerp(transform.localScale, targetScale, elapsedTime / _animTime);
                yield return null;
            }
            _button.interactable = show;
        }
    }
}