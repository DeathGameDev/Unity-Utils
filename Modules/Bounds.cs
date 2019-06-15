using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Utils
{
    /// <summary>
    /// Returns the screen rect of an object.
    /// </summary>
    public static Rect ToScreenSpace(this Bounds bounds, Camera camera)
    {
        float dist = Vector3.Distance(bounds.center, camera.transform.position);
        var origin = camera.WorldToScreenPoint(new Vector3(bounds.min.x, bounds.min.y, dist));
        var extents = camera.WorldToScreenPoint(new Vector3(bounds.max.x, bounds.min.y, dist));

        return new Rect(origin.x, Screen.height - origin.y, extents.x - origin.x, origin.y - extents.y);
    }
}