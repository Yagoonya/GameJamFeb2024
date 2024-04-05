using System;
using System.Collections;
using UnityEngine;

namespace Scripts.Vladick
{
    public class PlayCurrentSound : MonoBehaviour
    {
        [SerializeField] private AudioData[] _sounds;
        private AudioSource _source;

        public void Play(string id)
        {
            foreach (var audioData in _sounds)
            {
                if (audioData.Id != id) continue;

                if (_source == null)
                    _source = GameObject.FindWithTag("SfxAudioSource").GetComponent<AudioSource>();

                _source.PlayOneShot(audioData.Clip[0]);
                break;
            }
        }
        public void PlayMultiple(string id)
        {
            StartCoroutine(PlayMultipleCoroutine(id));
        }
        public void PlayBGVivivi(string id)
        {
            foreach (var audioData in _sounds)
            {
                if (audioData.Id != id) continue;

                if (_source == null)
                    _source = GameObject.FindWithTag("ViviviAudioSource").GetComponent<AudioSource>();

                _source.Play();
                break;
            }
        }
        private IEnumerator PlayMultipleCoroutine(string id)
        {
            foreach (var audioData in _sounds)
            {
                if (audioData.Id != id) continue;

                if (_source == null)
                    _source = GameObject.FindWithTag("SfxAudioSource").GetComponent<AudioSource>();

                foreach (var clip in audioData.Clip)
                {
                    _source.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length);
                }

                break;
            }
        }

        [Serializable]
        public class AudioData
        {
            [SerializeField] private string _id;
            [SerializeField] private AudioClip[] _clip;

            public string Id => _id;
            public AudioClip[] Clip => _clip;
        }
    }
}