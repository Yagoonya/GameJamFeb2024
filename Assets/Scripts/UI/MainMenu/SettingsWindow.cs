using Scripts.Model;
using Scripts.UI.MainMenu;
using UnityEngine;

namespace Scripts.UI
{
    public class SettingsWindow : MonoBehaviour
    {
        [SerializeField] private AudioSettingsWidget _music;
        [SerializeField] private AudioSettingsWidget _sfx;
        [SerializeField] private AudioSettingsWidget _radio;
        protected Animator _animator;
        private readonly static int Show = Animator.StringToHash("Show");
        private readonly static int Hide = Animator.StringToHash("Hide");
        private void Start()
        {
            _animator = GetComponent<Animator>();
            Open();
            _music.SetModel(GameSettings.I.Music);
            _sfx.SetModel(GameSettings.I.Sfx);
            _radio.SetModel(GameSettings.I.Radio);
        }

        public void Open()
        {
            _animator.SetTrigger(Show);
        }
        public void Close()
        {
            _animator.SetTrigger(Hide);
        }

        public void OnCloseAnimationComplete()
        {
            Destroy(gameObject);
        }
    }
}
