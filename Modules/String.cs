using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Utils
{
    public static string Substring(this string s, float startIndex, float? length = null)
    {
        if (length == null)
            return s.Substring((int)startIndex);
        else
            return s.Substring((int)startIndex, (int)length);
    }
}