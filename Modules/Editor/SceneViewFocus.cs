using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Helper class which forces the editor to retain focus in scene view when entering playmode.
/// Useful for when you don't intend on actually playing the game, but would instead just like to see it simulated in scene view.
/// </summary>
public static class SceneViewFocus
{
	private static class Content
	{
		public static readonly Texture2D PlayButton = EditorGUIUtility.FindTexture("d_PlayButton");
		public static readonly GUIContent LockOpen = EditorGUIUtility.TrIconContent("LockIcon", "Scene view will lose focus when entering play mode.");
		public static readonly GUIContent LockClosed = EditorGUIUtility.TrIconContent("LockIcon-On", "Scene view will retain focus when entering play mode.");
	}

	private static class Styles
	{
		public static readonly GUIStyle IconStyle = new GUIStyle(EditorStyles.label) { alignment = TextAnchor.MiddleCenter };

		public const float IconSize = 24;
		public const float IconSizeExtent = IconSize / 2f;
	}

	private static class Prefs
	{
		public static bool RetainFocus = true;
		public static bool DrawSceneToggle = true;
		private static bool prefsLoaded = false;

		private const string PREF_RETAINFOCUS = "UnityUtils_SceneViewFocus_RetainFocus";
		private const string PREF_DRAWSCENETOGGLE = "UnityUtils_SceneViewFocus_DrawSceneToggle";

		public static void DrawPreferences()
		{
			if (!prefsLoaded)
			{
				LoadPrefs();
				prefsLoaded = true;
			}

			EditorGUI.BeginChangeCheck();
			{
				RetainFocus = GUILayout.Toggle(RetainFocus, "Retain focus in scene view when entering play mode?");
				DrawSceneToggle = GUILayout.Toggle(DrawSceneToggle, "Draw switch at bottom right for toggling focus retention?");
			}
			if (EditorGUI.EndChangeCheck())
				SavePrefs();
		}

		public static void LoadPrefs()
		{
			RetainFocus = EditorPrefs.GetBool(PREF_RETAINFOCUS, false);
			DrawSceneToggle = EditorPrefs.GetBool(PREF_DRAWSCENETOGGLE, true);
		}

		public static void SavePrefs()
		{
			EditorPrefs.SetBool(PREF_RETAINFOCUS, RetainFocus);
			EditorPrefs.SetBool(PREF_DRAWSCENETOGGLE, DrawSceneToggle);
		}
	}

	[InitializeOnLoadMethod]
	private static void Init()
	{
		EditorApplication.playModeStateChanged += OnPlayStateChanged;
		SceneView.onSceneGUIDelegate += OnSceneGUI;
		Prefs.LoadPrefs();
	}

	[PreferenceItem("SceneViewFocus")]
	private static void DrawPreferences()
	{
		Prefs.DrawPreferences();
	}

	private static void OnPlayStateChanged(PlayModeStateChange state)
	{
		if (!Prefs.RetainFocus || state != PlayModeStateChange.EnteredPlayMode)
			return;
		EditorWindow.FocusWindowIfItsOpen<SceneView>();
	}

	private static void OnSceneGUI(SceneView sv)
	{
		if (!Prefs.DrawSceneToggle)
			return;

		Handles.BeginGUI();
		{
			Rect cameraGUIRect = sv.camera.pixelRect;
			float iconX = cameraGUIRect.width - 16;
			float iconY = cameraGUIRect.height - 17;
			Rect lockRect = new Rect(iconX - Styles.IconSizeExtent, iconY - Styles.IconSizeExtent, Styles.IconSize, Styles.IconSize);
			Rect playRect = lockRect;
			playRect.x -= Styles.IconSizeExtent;

			Rect buttonRect = playRect;
			buttonRect.width += Styles.IconSizeExtent;

			EditorGUI.BeginChangeCheck();
			{
				Prefs.RetainFocus = GUI.Toggle(buttonRect, Prefs.RetainFocus, GUIContent.none, Styles.IconStyle);
				GUI.Box(lockRect, Prefs.RetainFocus ? Content.LockClosed : Content.LockOpen, Styles.IconStyle);
				GUI.Box(playRect, Content.PlayButton, Styles.IconStyle);
			}
			if (EditorGUI.EndChangeCheck())
				Prefs.SavePrefs();

		}
		Handles.EndGUI();
	}
}