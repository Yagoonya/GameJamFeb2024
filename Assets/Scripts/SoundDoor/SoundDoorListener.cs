using Scripts.Vladick;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.SoundDoor
{
    public class SoundDoorListener : MonoBehaviour
    {
        [SerializeField] private float _inputTimeToLive;
        [SerializeField] private CodeItem[] _code;

        private string _currentInput;
        private float _inputTime;
        private VladickController _vladick;

        private void Awake()
        {
            _vladick = FindAnyObjectByType<VladickController>();
        }

        public void OnSoundInput()
        {
            _currentInput += _vladick.CurrentSound;
            _inputTime = _inputTimeToLive;
            FindCode();
        }

        private void FindCode()
        {
            foreach (var codeItem in _code)
            {
                if (_currentInput.Contains(codeItem.Name))
                {
                    codeItem.Action?.Invoke();
                    _currentInput = string.Empty;
                }
            }
        }

        private void Update()
        {
            if (_inputTime < 0)
            {
                _currentInput = string.Empty;
            }
            else
            {
                _inputTime -= Time.deltaTime;
            }
        }
    }


    [Serializable]
    public class CodeItem
    {
        public string Name;
        public UnityEvent Action;
    }

}