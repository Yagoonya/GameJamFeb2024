using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class GolovolomkaSliderList : MonoBehaviour
    {
        [SerializeField] private AudioClip[] _clips;
        private Slider _slider;
        private void Start()
        {
            _slider = GetComponent<Slider>();
        }
        public AudioClip GetSliderClip()
        {
            return _clips[(int)_slider.value];
        }
        public int GetSliderValue()
        {
            return (int)_slider.value;
        }
    }
}
