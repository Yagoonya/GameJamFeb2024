using System;
using UnityEngine;

namespace Scripts.Model
{
    [CreateAssetMenu(menuName = "Defs/SoundItem", fileName = "SoundItem")]
    public class SoundItemsDef : ScriptableObject
    {
        [SerializeField] private SoundDef[] _sound;
        public SoundDef Get(string id)
        {
            foreach (var soundDef in _sound)
            {
                if (soundDef.Id == id)
                    return soundDef;
            }
            return default;
        }
#if UNITY_EDITOR
        public SoundDef[] SoundForEditor => _sound;
#endif
    }

    [Serializable]
    public struct SoundDef
    {
        [SerializeField] private string _id;

        public string Id => _id;
        public bool IsVoid => string.IsNullOrEmpty(_id);
    }
}
