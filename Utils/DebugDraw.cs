using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Utils
{
    /// <summary>
    /// Draws the debug information for this point using the Debug.DrawLine toolset.
    /// </summary>
    /// <param name="point">The position in space to portray.</param>
    /// <param name="c">The color to draw with</param>
    /// <param name="duration">The duration this will stay alive</param>
    /// <param name="size">The size of the point's outward lines.</param>
    public static void DrawDebug(this Vector3 point, Color c = default(Color), float duration = 1f, float size = 0.1f)
    {
        c = (c == default(Color)) ? Color.white : c;

        Vector3[] directions =
        {
            Vector3.up,
            -Vector3.up,
            Vector3.right,
            -Vector3.right,
            Vector3.forward,
            -Vector3.forward
        };

        foreach (Vector3 dir in directions)
            Debug.DrawLine(point, point + (dir * size), c, duration);
    }

    /// <summary>
    /// Draws the debug information for this line using the Debug.DrawLine toolset.
    /// </summary>
    /// <param name="b">The box Collider2D to draw.</param>
    /// <param name="c">The color to draw in.</param>
    public static void DrawDebug(this BoxCollider2D b, Color c = default(Color))
    {
        c = (c == default(Color)) ? Color.white : c;

        Vector3 pos = b.gameObject.transform.position;
        List<Vector2> l = new List<Vector2>();
        l.Add(new Vector2(pos.x - b.bounds.extents.x, pos.y + b.bounds.extents.y));     //Top Left
        l.Add(new Vector2(pos.x + b.bounds.extents.x, pos.y + b.bounds.extents.y));     //Top right
        l.Add(new Vector2(pos.x + b.bounds.extents.x, pos.y - b.bounds.extents.y));     //Bottom right
        l.Add(new Vector2(pos.x - b.bounds.extents.x, pos.y - b.bounds.extents.y));     //Bottom Left
        dl(l[0], l[1], c);
        dl(l[1], l[2], c);
        dl(l[2], l[3], c);
        dl(l[3], l[0], c);
    }

    /// <summary>
    /// Shorthand function for drawing lines
    /// </summary>
    /// <param name="a">The starting position</param>
    /// <param name="b">The ending position</param>
    /// <param name="c">The color to draw the line</param>
    private static void dl(Vector2 a, Vector2 b, Color? c = null)
    {
        c = c ?? Color.white;
        Debug.DrawLine(a, b, (Color) c);
    }
}