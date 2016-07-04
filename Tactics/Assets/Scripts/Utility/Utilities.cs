using UnityEngine;
using System.Collections;

public static class Utilities
{

    public static bool isInLayerMask(GameObject obj, LayerMask mask)
    {
        return ((mask.value & (1 << obj.layer)) > 0);
    }
}
