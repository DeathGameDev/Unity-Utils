using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static partial class Utils
{
    /// <summary>
    /// Adds an object to this array.
    /// </summary>
    public static void Add<T>(this T[] array, T obj)
    {
        T[] arr = new T[array.Length + 1];
        Array.Copy(array, arr, array.Length);
        arr[array.Length + 1] = obj;
        array = arr;
    }

    /// <summary>
    /// Returns a random item in this array.
    /// </summary>
    public static T GetRandom<T>(this T[] array)
    {
        return array[UnityEngine.Random.Range(0, array.Length)];
    }

    /// <summary>
    /// Converts an array of Type to an array of generalized objects.
    /// </summary>
    public static object[] ToObjectArray<T>(this T[] array)
    {
        return Array.ConvertAll(array, t => (object)t);
    }
}