#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static partial class Utils
{
	public static T CreateChildAsset<T>(this ScriptableObject so, string name = null) where T : ScriptableObject
	{
		if (!EditorUtility.IsPersistent(so))
			return null;

		T instance = ScriptableObject.CreateInstance<T>();
		instance.name = (name == null) ? typeof(T).Name : name;
		AssetDatabase.AddObjectToAsset(instance, so);
		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();

		return instance;
	}

	public static bool TryCreateChildAsset<T>(this ScriptableObject so, out T instance, string name = null) where T : ScriptableObject
	{
		if (!EditorUtility.IsPersistent(so))
		{
			instance = null;
			return false;
		}

		instance = ScriptableObject.CreateInstance<T>();
		instance.name = (name == null) ? typeof(T).Name : name;
		AssetDatabase.AddObjectToAsset(instance, so);
		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();

		return true;
	}
}
#endif