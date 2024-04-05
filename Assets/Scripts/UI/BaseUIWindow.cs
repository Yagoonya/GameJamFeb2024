using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.UI
{
    public class BaseUIWindow : MonoBehaviour
    {
        protected Animator _animator;
        protected PlayerInput _playerInput;
        public virtual void OnEnable()
        {
            Open();
        }
        public virtual void Open()
        {
            _animator = GetComponent<Animator>();
            _playerInput = FindObjectOfType<PlayerInput>();
            Time.timeScale = 0;
            _playerInput.SwitchCurrentActionMap("UI numpad");
        }
        public virtual void Close()
        {
            _animator.SetTrigger("Hide");
        }
        public virtual void OnCloseAnimationComplete()
        {
            gameObject.SetActive(false);
            _playerInput.SwitchCurrentActionMap("VladickMovement");
            Time.timeScale = 1;
        }
    }
}
