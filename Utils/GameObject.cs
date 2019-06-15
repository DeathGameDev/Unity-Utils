using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static partial class Utils
{
    /// <summary>
    /// Returns a child of this object, with name as index.
    /// </summary>
    public static GameObject GetChild(this GameObject g, string name)
    {
        if (g.transform.childCount == 0)
        {
            Debug.LogError("No children were found for the given transform!");
            return null;
        }

        GameObject[] children = g.transform.GetComponentsInChildren<Transform>().Select(t => t.gameObject).ToArray();

        foreach (GameObject child in children)
        {
            if (child.name == name)
                return child;
        }

        return null;
    }

    /// <summary>
    /// Returns all children of this object.
    /// </summary>
    /// <param name="g"></param>
    /// <param name="recursive"></param>
    /// <returns></returns>
    public static GameObject[] GetChildren(this GameObject g, bool recursive = false)
    {
        if (recursive)
            return g.GetComponentsInChildren<Transform>().Select(t => t.gameObject).ToArray();
        else
            return g.GetComponentsInChildren<Transform>().Where(t => t.parent == g.transform).Select(t => t.gameObject).ToArray();
    }

    /// <summary>
    /// Null safe version of GetChild.
    /// </summary>
    public static bool TryGetChild(this GameObject g, string name, out GameObject returnObj)
    {
        returnObj = g.GetChild(name);
        return returnObj != null;
    }

    /// <summary>
    /// Tries to get a component, if none exists, adds it.
    /// </summary>
    public static T GetOrAddComponent<T>(this GameObject g) where T : Component
    {
        if (g.GetComponent<T>() != null)
            return g.GetComponent<T>();
        else
            return g.AddComponent<T>();
    }
    public static T GetOrAddComponent<T>(this Transform t) where T : Component
    {
        return t.gameObject.GetOrAddComponent<T>();
    }

    /// <summary>
    /// Attempts to get a component from an object.
    /// </summary>
    public static bool TryGetComponent<T>(this GameObject g, out T component)
    {
        if (g.GetComponent<T>() != null)
        {
            component = g.GetComponent<T>();
            return true;
        }
        else
        {
            component = default(T);
            return false;
        }
    }

    /// <summary>
    /// Removes a component from a gameobject.
    /// </summary>
    public static void RemoveComponent<T>(this GameObject g)
    {
        if (g.GetComponent<T>() != null)
            MonoBehaviour.Destroy(g.GetComponent<T>() as Component);
        else
            throw new System.NullReferenceException("Failed to find the requested component on this object!");
    }

    /// <summary>
    /// Null safe version of RemoveComponent
    /// </summary>
    public static void TryRemoveComponent<T>(this GameObject g)
    {
        if (g.GetComponent<T>() != null)
            MonoBehaviour.Destroy(g.GetComponent<T>() as Component);
    }

    public static float DistanceTo(this GameObject a, GameObject b)
    {
        return Vector3.Distance(a.transform.position, b.transform.position);
    }
}