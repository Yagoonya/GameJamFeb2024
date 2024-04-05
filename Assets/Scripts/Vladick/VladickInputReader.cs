using Scripts.UI;
using Scripts.UI.Menus;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.Vladick
{
    public class VladickInputReader : MonoBehaviour
    {
        [SerializeField] private VladickController _vladick;
        [SerializeField] private RadioMenu _menu;
        private PlayerInput _playerInput;

        public void Start()
        {
            _playerInput = GetComponent<PlayerInput>();
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            _vladick.SetDirection(direction);
        }

        public void OnPlaySound(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                var name = context.action.name;
                _vladick.PlaySound(name);
            }
        }
        public void OnRadioMenu(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _menu.gameObject.SetActive(true);
            }
        }
        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _vladick.InteractNoSound();
            }
        }
        public void SwitchMap(InputAction.CallbackContext context)
        {
            _playerInput.SwitchCurrentActionMap("");
        }
        public void OnUICancel(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                var windowsToClose = FindObjectsOfType<BaseUIWindow>();
                foreach (var window in windowsToClose)
                {
                    window.Close();
                }
            }
        }
    }
}
