using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static partial class Utils
{
    #region Vector2
    /// <summary>
    /// Converts a Screen-Space Vector2 to World-Space
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public static Vector2 ToWorld(this Vector2 v, Camera c = null)
    {
        c = (c == null) ? Camera.main : c;
        return c.ScreenToWorldPoint(v);
    }

    /// <summary>
    /// Converts a World-Space Vector2 to Screen-Space
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public static Vector2 ToScreen(this Vector2 v)
    {
        return Camera.main.WorldToScreenPoint(v);
    }

    public static float ToAngle(this Vector2 v)
    {
        return Mathf.Atan2(v.y, v.x);
    }

    public static Vector2 DirectionFromAngle(float angle, bool isRadians = false)
    {
        if (!isRadians)
        {
            angle -= 90;    //Making the top be the origin
            angle = angle * Mathf.Deg2Rad;
        }
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    public static List<Vector2> Add(this List<Vector2> l, float x, float y)
    {
        l.Add(new Vector2(x, y));
        return l;
    }
    public static Vector2 Multiply(this Vector2 a, Vector2 b)
    {
        return new Vector2(a.x * b.x, a.y * b.y);
    }
    public static Vector2 Divide(this Vector2 a, Vector2 b)
    {
        return new Vector2(a.x / b.x, a.y / b.y);
    }
    public static Vector3[] ToVec3Array(this Vector2[] vArr)
    {
        return vArr.Select(v => (Vector3) v).ToArray();
    }
    #endregion
    #region Vector3
    public static Vector3 ToWorld(this Vector3 v)
    {
        return Camera.main.ScreenToWorldPoint(v);
    }
    public static Vector2 ToScreen(this Vector3 v)
    {
        return Camera.main.WorldToScreenPoint(v);
    }
    public static Vector3 Add(this Vector3 v, float f)
    {
        return new Vector3(v.x + f, v.y + f, v.z + f);
    }
    public static Vector3 Add(this Vector3 v, float f, params Axis[] a)
    {
        foreach (Axis _a in a)
        {
            switch (_a)
            {
                case Axis.x:
                    v = new Vector3(v.x + f, v.y, v.z);
                    break;
                case Axis.y:
                    v = new Vector3(v.x, v.y + f, v.z);
                    break;
                case Axis.z:
                    v = new Vector3(v.x, v.y, v.z + f);
                    break;
            }
        }
        return v;
    }
    public static Vector3 Subtract(this Vector3 v, float f)
    {
        return new Vector3(v.x - f, v.y - f, v.z - f);
    }
    public static Vector3 Subtract(this Vector3 v, float f, params Axis[] a)
    {
        foreach (Axis _a in a)
        {
            switch (_a)
            {
                case Axis.x:
                    v = new Vector3(v.x - f, v.y, v.z);
                    break;
                case Axis.y:
                    v = new Vector3(v.x, v.y - f, v.z);
                    break;
                case Axis.z:
                    v = new Vector3(v.x, v.y, v.z - f);
                    break;
            }
        }
        return v;
    }
    public static Vector3 Multiply(this Vector3 a, Vector3 b)
    {
        return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
    }
    public static Vector3 Multiply(this Vector3 v, float f)
    {
        return new Vector3(v.x * f, v.y * f, v.z * f);
    }
    public static Vector3 Divide(this Vector3 a, Vector3 b)
    {
        return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
    }
    public static bool LessThan(this Vector3 a, Vector3 b)
    {
        return (a.x < b.x && a.y < b.y && a.z < b.z);
    }
    public static bool GreaterThan(this Vector3 a, Vector3 b)
    {
        return (a.x > b.x && a.y > b.y && a.z > b.z);
    }
    public static bool IsAround(this Vector3 a, Vector3 b, float offset)
    {
        Vector3 bNegative = b.Subtract(offset);
        Vector3 bPositive = b.Add(offset);
        return a.LessThan(bPositive) && a.GreaterThan(bNegative);
    }
    public static Vector2[] ToVec2Array(this Vector3[] vArr)
    {
        List<Vector2> m_list = new List<Vector2>();
        foreach (Vector3 v in vArr)
            m_list.Add((Vector2)v);
        return m_list.ToArray();
    }
    #endregion
}
