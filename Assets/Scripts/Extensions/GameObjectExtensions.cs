using UnityEngine;

namespace Scripts.Extensions
{
    public static class GameObjectExtensions
    {
        public static bool IsInLayer(this GameObject gameObject, LayerMask layerMask)
        {
            return layerMask == (layerMask | 1 << gameObject.layer);
        }
    }
}