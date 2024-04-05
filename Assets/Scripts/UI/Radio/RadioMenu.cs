using Scripts.UI.Widgets;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Scripts.UI.Menus
{
    public class RadioMenu : BaseUIWindow
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private RadioSliderWidget _radioWidget;


        public override void Open()
        {
            _animator = GetComponent<Animator>();
            _playerInput = FindObjectOfType<PlayerInput>();
            _playerInput.SwitchCurrentActionMap("UI numpad");
            _slider.Select();
            Time.timeScale = 0;
            _radioWidget.InitWindow();
        }

        public override void Close()
        {
            _radioWidget.CloseWindow();
            base.Close();
        }

    }
}
