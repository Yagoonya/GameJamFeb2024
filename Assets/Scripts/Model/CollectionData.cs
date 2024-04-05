using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Model
{
    [Serializable]
    public class CollectionData
    {
        [SerializeField] private List<SoundItemData> _collection = new List<SoundItemData>();

        public delegate void OnInventoryChanged(string id);

        public OnInventoryChanged onChanged;

        public void Add(string id)
        {
            var soundDef = DefsFacade.I.Sounds.Get(id);
            if (soundDef.IsVoid) return;


            var sound = new SoundItemData(id);
            _collection.Add(sound);

            onChanged?.Invoke(id);
        }

        public SoundItemData GetSound(string id)
        {
            foreach (var soundData in _collection)
            {
                if (soundData.Id == id)
                    return soundData;
            }
            return null;
        }
    }

    [Serializable]
    public class SoundItemData
    {
        public string Id;

        public SoundItemData(string id)
        {
            Id = id;
        }
    }
}