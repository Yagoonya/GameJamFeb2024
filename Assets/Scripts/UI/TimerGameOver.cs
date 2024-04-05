using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.UI
{
    public class TimerGameOver : MonoBehaviour
    {
        [SerializeField] private int _initialTime = 5;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private UnityEvent _endTimerEvent;


        private float timer;
        private void Start()
        {
            timer = _initialTime * 60;
        }

        private void Update()
        {
            if (timer <= 0)
            {
                _endTimerEvent.Invoke();
            }
            timer -= Time.unscaledDeltaTime;

            UpdateTimerUI();
        }

        public void Punish()
        {
            timer -= 60;
            UpdateTimerUI();
        }

        private void UpdateTimerUI()
        {
            int minutes = Mathf.FloorToInt(timer / 60F);
            int seconds = Mathf.FloorToInt(timer - minutes * 60);

            _text.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        }
    }
}