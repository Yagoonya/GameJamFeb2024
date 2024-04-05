using Scripts.Model;
using UnityEngine;

namespace Scripts.Interactions
{
    public class AddSoundCollection : MonoBehaviour
    {

        [SerializeField] private string _id;

        public void Add()
        {
            var session = FindAnyObjectByType<GameSession>();
            session?.AddSound(_id);
        }

    }
}
