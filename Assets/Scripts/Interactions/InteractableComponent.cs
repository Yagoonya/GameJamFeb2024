using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Interactions
{
    internal class InteractableComponent : MonoBehaviour
    {
        [SerializeField] UnityEvent _action;

        public void Interact()
        {
            _action.Invoke();
        }
    }
}
