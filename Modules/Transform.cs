using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static partial class Utils
{
    public static void SetAxis(this Transform t, float f, params Axis[] a)
    {
        foreach (Axis _a in a)
        {
            Vector3 pos = t.position;
            switch (_a)
            {
                case Axis.x:
                    pos.x = f;
                    break;
                case Axis.y:
                    pos.y = f;
                    break;
                case Axis.z:
                    pos.z = f;
                    break;
            }
            t.position = pos;
        }
    }

    public static Transform[] GetChildren(this Transform t, bool recursive = false)
    {
        if (recursive)
            return t.GetComponentsInChildren<Transform>();
        else
            return t.GetComponentsInChildren<Transform>().Where(x => x.parent == t).ToArray();
    }

    public static Transform GetRootParent(this Transform t)
    {
        while (t.parent != null)
            t = t.parent;
        return t;
    }

    public static void DestroyChildren(this Transform t)
    {
        for (int i = t.childCount - 1; i >= 0; i--)
            MonoBehaviour.Destroy(t.GetChild(i));
    }
}
