using System;
using UnityEngine;
using UnityEngine.Events;


namespace Scripts.UI
{
    public class RadioSoundList : MonoBehaviour
    {

        [SerializeField] private RadioData[] _radioFrequency;

        [SerializeField] private AudioSource _noiseSource;
        [SerializeField] private AudioSource _frequencySource;

        public RadioData[] RadioFrequency => _radioFrequency;
        public AudioSource NoiseSource => _noiseSource;
        public AudioSource FrequencySource => _frequencySource;


        private void Awake()
        {
            _frequencySource = GameObject.FindWithTag("RadioAudioSource").GetComponent<AudioSource>();
            _noiseSource = GameObject.FindWithTag("RadioNoiseSource").GetComponent<AudioSource>();
        }

    }

    [Serializable]
    public class RadioData
    {
        public float frequencyId;
        public AudioClip sound;
        [SerializeField] public UnityEvent frequencyAction;
    }
}