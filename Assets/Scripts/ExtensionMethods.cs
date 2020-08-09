using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    public static Vector3 GetRandomOffsetedVectorFromPoint(this Vector3 vect, float offset)
    {
        vect.x += Random.Range(-offset, offset);
        vect.y += Random.Range(-offset, offset);
        vect.z += Random.Range(-offset, offset);
        return vect;
    }
}
