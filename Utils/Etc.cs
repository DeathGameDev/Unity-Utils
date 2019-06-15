using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Utils
{
    /// <summary>
    /// Returns a direction from a given angle
    /// </summary>
    public static Vector2 DirFromAngle(float angle, bool isRadians = false)
    {
        //It's already in radians, so go ahead and return it.
        if (isRadians) return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        //It's not radians, so adjust the angle.
        angle -= 90;    //Making the top be the origin
        angle = angle * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    /// <summary>
    /// Returns a point on the edge of a circle
    /// </summary>
    public static Vector2 GetPointInCircle(Vector2 center, Vector2 direction, float dist)
    {
        return center + direction * dist;
    }

	public delegate void CirclePointsCallback(Vector2 point, Vector2 direction);
	public delegate void CirclePointsCallbackWithPrevious(Vector2 point, Vector2 previousPoint, Vector2 direction);
	/// <summary>
	/// 
	/// </summary>
	/// <param name="center"></param>
	/// <param name="radius"></param>
	/// <param name="pointCount"></param>
	public static void ForeachPointOnCircle(Vector2 center, float radius, int pointCount, CirclePointsCallback callback)
	{
		float computedPointCount = 360f / pointCount;
		for (int i = 0; i < pointCount; i++)
		{
			float f = ((i * computedPointCount) * Mathf.PI) / 180;
			Vector2 lineDir = new Vector2(Mathf.Cos(f), Mathf.Sin(f));
			callback(center + (lineDir * radius), lineDir);
		}
	}

	public static Vector2[] GetCirclePoints(Vector2 center, float radius, int pointCount)
	{
		float computedPointCount = 360f / pointCount;
		Vector2[] vArr = new Vector2[pointCount];
		for (int i = 0; i < vArr.Length; i++)
		{
			float f = ((i * computedPointCount) * Mathf.PI) / 180;
			Vector2 lineDir = new Vector2(Mathf.Cos(f), Mathf.Sin(f));
			vArr[i] = center + (lineDir * radius);
		}

		return vArr;
	}

	//Sets the vertices of a LineRenderer
	public static void SetVertices(this LineRenderer l, Vector2[] verts)
    {
        l.positionCount = verts.Length;
        l.SetPositions(verts.ToVec3Array());
    }
}