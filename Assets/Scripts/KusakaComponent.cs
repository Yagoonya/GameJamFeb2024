using UnityEngine;
using UnityEngine.Events;

namespace Scripts
{
    public class KusakaComponent : MonoBehaviour
    {
        [SerializeField] private UnityEvent _gameOver;
        [SerializeField] private float _timeToGameOver;
        [SerializeField] private AudioSource _audioSource;

        private float _timeToReset;

        private bool _isKusakaActive;

        private void Start()
        {
            _timeToReset = _timeToGameOver;
        }

        public void StartKusaker()
        {
            _audioSource.Play();
            _isKusakaActive = true;
        }

        public void StopKusaker()
        {
            _isKusakaActive = false;
        }

        [ContextMenu("RESET")]      
        public void ResetKusaker()
        {
            _timeToGameOver = _timeToReset;
            _timeToGameOver++;
        }

        private void SetKusakaVolume(float volume)
        {
            var percent = _timeToReset / 10f;
            var volumeValue = percent / volume;
            _audioSource.volume = volumeValue;
        }

        private void Update()
        {
            if (_isKusakaActive)
            {
                if (_timeToGameOver > 0)
                {
                    _timeToGameOver -= Time.deltaTime;
                    SetKusakaVolume(_timeToGameOver);
                }
                else
                {
                    Debug.Log("Тоби пiзда!");
                    _gameOver?.Invoke();
                    _audioSource.Stop();
                    _isKusakaActive=false;
                }
            }
        }


    }
}