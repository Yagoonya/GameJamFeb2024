using Scripts.General.Utils;
using UnityEngine;

namespace Scripts.Model
{
    [CreateAssetMenu(menuName = "Data/GameSettings", fileName = "GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private FloatPersistentProperty _music;
        [SerializeField] private FloatPersistentProperty _sfx;
        [SerializeField] private FloatPersistentProperty _radio;

        public FloatPersistentProperty Music => _music;
        public FloatPersistentProperty Sfx => _sfx;
        public FloatPersistentProperty Radio => _radio;

        private static GameSettings _instance;
        public static GameSettings I => _instance == null ? LoadGameSettings() : _instance;

        private static GameSettings LoadGameSettings()
        {
            return _instance = Resources.Load<GameSettings>("GameSettings");
        }

        private void OnEnable()
        {
            _music = new FloatPersistentProperty(1f, SoundSetting.Music.ToString());
            _sfx = new FloatPersistentProperty(1f, SoundSetting.SFX.ToString());
            _radio = new FloatPersistentProperty(1f, SoundSetting.Radio.ToString());
        }
        private void OnValidate()
        {
            _music.Validate();
            _sfx.Validate();
            _radio.Validate();
        }
    }
    public enum SoundSetting
    {
        Music,
        SFX,
        Radio
    }
}