using Scripts.SoundDoor;
using System;
using System.Collections;
using UnityEngine;

namespace Scripts.Vladick
{
    public class PlaySoundComponent : MonoBehaviour
    {
        public void DoInteraction(GameObject go)
        {
            var interactable = go.GetComponent<SoundDoorListener>();
            if (interactable != null)
            {
                interactable.OnSoundInput();
            }
        }
    }
}