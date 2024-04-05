using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class SliderGolovolomka : BaseUIWindow
    {
        [SerializeField] UnityEvent _onStartEvent;
        [SerializeField] string _answer;
        public bool IsNoSound = true;

        [SerializeField] private Slider primarySlider;
        private AudioSource _source;
        [SerializeField] UnityEvent _onValidPass;

        [SerializeField] private GolovolomkaSliderList[] golovolomkaSliderLists;



        private string currentPass;

        private void Start()
        {
            _source = GetComponent<AudioSource>();
            _source.ignoreListenerPause = true;
        }
        public void onoff()
        {
            IsNoSound = false;
        }
        public void PlaySong()
        {
            StartCoroutine(PlaySongWithDelay());
        }
        public void PlayCurrentSliderSong(int i)
        {
            var clip = golovolomkaSliderLists[i].GetSliderClip();
            if(!IsNoSound)
            _source.PlayOneShot(clip);

        }
        private IEnumerator PlaySongWithDelay()
        {
            foreach (var slider in golovolomkaSliderLists)
            {
                var clip = slider.GetSliderClip();

                if(!IsNoSound)
                _source.PlayOneShot(clip);

                yield return new WaitForSecondsRealtime(0.5f);
            }
            checkPass();
        }
        private void checkPass()
        {
            foreach (var slider in golovolomkaSliderLists)
            {
                currentPass += slider.GetSliderValue().ToString();
            }
            if (currentPass.Contains(_answer))
            {
                _onValidPass?.Invoke();
            }
            Debug.Log("my pass - " + currentPass);
            Debug.Log("need pass - " + _answer);

            currentPass = string.Empty;
        }
        public override void Open()
        {
            base.Open();
            if (IsNoSound)
            {
                _onStartEvent?.Invoke();
            }
            primarySlider.Select();
        }
    }
}