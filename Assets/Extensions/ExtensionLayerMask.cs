using UnityEngine;

namespace Assets.Extensions
{
    public static class ExtensionLayerMask
    {
        public static bool IsLayerInMask(this UnityEngine.LayerMask mask, int layer)
        {
            return (mask.value & (1 << layer)) != 0;
        }
    }
}
