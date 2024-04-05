using Scripts.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Scripts.UI.Widgets
{
    public class RadioSliderWidget : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _value;

        [SerializeField] private RadioSoundList _radioSoundList;
        [SerializeField] private float _threshold = 10.0f;


        private void Start()
        {
            _slider.onValueChanged.AddListener(ObSliderValueChanged);
        }


        public void InitWindow()
        {
            _radioSoundList.FrequencySource.volume = 0f;
            _radioSoundList.NoiseSource.volume = GameSettings.I.Radio.Value;
            _slider.value = 68f * 2;
        }
        public void CloseWindow()
        {
            _radioSoundList.FrequencySource.volume = 0f;
            _radioSoundList.NoiseSource.volume = 0f;

        }
        private void ObSliderValueChanged(float value)
        {
            _value.text = (value / 2).ToString("F2");
            UpdateFrequency(value / 2);
        }
        private void UpdateFrequency(float value)
        {
            RadioData closestFrequency = FindClosestFrequency(value);

            if (closestFrequency != null)
            {
                float distance = Mathf.Abs(value - closestFrequency.frequencyId);

                _radioSoundList.FrequencySource.volume = Mathf.Lerp(0.0f, GameSettings.I.Radio.Value, Mathf.Clamp01(1.0f - distance / _threshold));
                _radioSoundList.NoiseSource.volume = Mathf.Lerp(GameSettings.I.Radio.Value, 0.0f, Mathf.Clamp01(1.0f - distance / _threshold));

                if (_radioSoundList.FrequencySource.clip != closestFrequency.sound)
                {
                    _radioSoundList.FrequencySource.clip = closestFrequency.sound;
                    _radioSoundList.FrequencySource.Play();
                    closestFrequency.frequencyAction?.Invoke();
                }
            }
        }
        private RadioData FindClosestFrequency(float value)
        {
            float closestDistance = float.MaxValue;
            RadioData closestFrequency = null;

            foreach (RadioData frequency in _radioSoundList.RadioFrequency)
            {
                float distance = Mathf.Abs(value - frequency.frequencyId);

                if (distance < _threshold && distance < closestDistance)
                {
                    closestDistance = distance;
                    closestFrequency = frequency;
                }
            }

            return closestFrequency;
        }

        private void OnDestroy()
        {
            _slider.onValueChanged.RemoveListener(ObSliderValueChanged);
        }
    }
}
