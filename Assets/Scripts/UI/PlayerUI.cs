using System;
using UnityEngine;

namespace Scripts.UI
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] UIElement[] elements;
        public void UnlockUIElement(string id)
        {
            foreach (var element in elements)
            {
                if (element.Id != id) continue;

                element.ElementUI.SetActive(true);
                break;
            }
        }
    }
    [Serializable]
    public class UIElement
    {
        [SerializeField] string _id;
        [SerializeField] GameObject _elementUI;

        public string Id => _id;
        public GameObject ElementUI => _elementUI;

    }
}
