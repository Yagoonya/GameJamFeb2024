using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.UI
{
    public class MainMenuWindow : MonoBehaviour
    {
        private Action _closeAction;
        private Animator _animator;
        private readonly static int Show = Animator.StringToHash("Show");
        private readonly static int Hide = Animator.StringToHash("Hide");

        public void OnShowSettings()
        {
            var window = Resources.Load<GameObject>("UI/SettingsWindow");
            var canvas = FindObjectOfType<Canvas>();
            Instantiate(window, canvas.transform);
        }
        public void OnStartGame()
        {
            _closeAction = () =>
            {
                SceneManager.LoadScene("Scene1");
            };
            Close();
        }

        public void Start()
        {
            _animator = GetComponent<Animator>();
            Open();
        }
        public void Open()
        {
            _animator.SetTrigger(Show);
        }
        public void Close()
        {
            _animator.SetTrigger(Hide);
        }

        public void OnExit()
        {
            _closeAction = () =>
            {
                Application.Quit();

#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            };
            Close();
        }
        public void OnCloseAnimationComplete()
        {
            Destroy(gameObject);
            _closeAction?.Invoke();

        }
    }
}