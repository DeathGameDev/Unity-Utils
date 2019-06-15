using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public static partial class Utils
{
    /// <summary>
    /// Returns if this number is around a given number, with a given tolerance.
    /// </summary>
    public static bool IsAround(this float a, float b, float tolerance)
    {
        return Math.Abs(a - b) < tolerance;
    }

    /// <summary>
    /// Converts a potentially null float to a non nullable float.
    /// </summary>
    public static float ToNonNullable(this float? f)
    {
        return f ?? 0;
    }

	#region ShortHands

#if NET_4_6
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
	public static float Abs(this float f)
	{
		return Math.Abs(f);
	}

#if NET_4_6
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
	public static float Clamp(this float f, float min, float max)
	{
		if (f < min)
			return min;
		else if (f > max)
			return max;
		return f;
	}

#if NET_4_6
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
	public static float Floor(this float f)
	{
		return (float)Math.Floor(f);
	}

#if NET_4_6
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
	public static int FloorToInt(this float f)
	{
		return (int) Math.Floor(f);
	}

#if NET_4_6
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
	public static float Normalize(this float f, float max)
	{
		return f / max;
	}

#if NET_4_6
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
	public static float Normalize(this float f, float min, float max)
	{
		return (f - min) / (max - min);
	}
#endregion
}