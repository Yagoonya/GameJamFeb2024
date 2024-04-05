using System;
using UnityEngine;

namespace Scripts.Model
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField] private CollectionData _collection;

        public CollectionData Collection => _collection;

        public PlayerData Clone()
        {
            var json = JsonUtility.ToJson(this);
            return JsonUtility.FromJson<PlayerData>(json);
        }
    }

}
