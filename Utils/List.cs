using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Utils
{
    /// <summary>
    /// Removes an object from a list at index i, and returns the list.
    /// </summary>
    public static List<T> RemoveAtAndReturn<T>(this List<T> list, int index)
    {
        if (list.Count < index)
            throw new System.IndexOutOfRangeException();
        list.RemoveAt(index);
        return list;
    }

    /// <summary>
    /// Converts a list of Type to an array of generalized objects.
    /// </summary>
    public static object[] ToObjectArray<T>(this List<T> list)
    {
        return Array.ConvertAll(list.ToArray(), t => (object)t);
    }

    /// <summary>
    /// Returns a random object within a list.
    /// </summary>
    public static T GetRandom<T>(this List<T> l)
    {
        return l[UnityEngine.Random.Range(0, l.Count)];
    }
}