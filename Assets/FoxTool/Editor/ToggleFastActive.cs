//==============================================================
//  Create by fox at 2017-3-18
//==============================================================

using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FoxTool
{
	public class ToggleFastActive
	{
		public const string MenuItemName = "FoxTool/FastToggleActive";

		[InitializeOnLoadMethod]
		public static void Init()
		{
			Register();
		}

		public static bool IsShow
		{
			get { return PlayerPrefs.GetInt("ToggleFastActive", 0) != 0; }

			set { PlayerPrefs.SetInt("ToggleFastActive", value ? 1 : 0); }
		}

		[MenuItem(MenuItemName)]
		public static void FastToggleActive()
		{
			IsShow = !IsShow;

			Register();
		}

		public static void Register()
		{
			if (IsShow)
			{
				EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGui;
			}
			else
			{
				// ReSharper disable once DelegateSubtraction
				EditorApplication.hierarchyWindowItemOnGUI -= HierarchyWindowItemOnGui;
			}

			Menu.SetChecked(MenuItemName, IsShow);
		}


		private static void HierarchyWindowItemOnGui(int instanceID, Rect selectionRect)
		{
			GameObject obj = (GameObject) EditorUtility.InstanceIDToObject(instanceID);
			if (obj)
			{
				bool active = EditorGUI.Toggle(new Rect(selectionRect.x + selectionRect.width - 20f, selectionRect.y, 16, 16),
					obj.activeSelf);
				if (obj.activeSelf != active && !Application.isPlaying)
				{
					EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
				}
				obj.SetActive(active);
			}
		}
	}
}
