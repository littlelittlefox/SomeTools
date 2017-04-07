//==============================================================
//  Create by fox at 2017/4/6
//==============================================================

using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class FastApply
{
	public const string MenuItemName = "FoxTool/FastApply";

	public static string LastPath = "Assets";

	[InitializeOnLoadMethod]
	public static void Init()
	{
		Register();
	}

	public static bool IsShow
	{
		get { return PlayerPrefs.GetInt("FastApply", 0) != 0; }

		set { PlayerPrefs.SetInt("FastApply", value ? 1 : 0); }
	}

	[MenuItem(MenuItemName)]
	public static void ApplyFast()
	{
		IsShow = !IsShow;
		Menu.SetChecked(MenuItemName, IsShow);
		Register();
	}

	[MenuItem(MenuItemName, true)]
	public static bool ApplyFastCheck()
	{
		Menu.SetChecked(MenuItemName, IsShow);
		return true;
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
	}

	private static void HierarchyWindowItemOnGui(int instanceID, Rect selectionRect)
	{
		GameObject obj = (GameObject) EditorUtility.InstanceIDToObject(instanceID);
		if (obj)
		{
			Object o = PrefabUtility.GetPrefabParent(obj);

			//这是只处理prefab的情况
//			if (o != null)
//			{
//				GUIStyle style = new GUIStyle(GUI.skin.button) { fontSize = 9 };
//				if (GUI.Button(new Rect(selectionRect.x + selectionRect.width - 54, selectionRect.y, 50, 14), "apply", style))
//				{
//					PrefabUtility.ReplacePrefab(PrefabUtility.FindPrefabRoot(obj), o, ReplacePrefabOptions.ConnectToPrefab);
//				}
//			}
			
			//这个是：如果不是prefab就弹框框选择保存prefab的位置
			GUIStyle style = new GUIStyle(GUI.skin.button) {fontSize = 9};
			if (GUI.Button(new Rect(selectionRect.x + selectionRect.width - 54, selectionRect.y, 50, 14), "apply", style))
			{
				if (o != null)
					PrefabUtility.ReplacePrefab(PrefabUtility.FindPrefabRoot(obj), o, ReplacePrefabOptions.ConnectToPrefab);
				else
				{
					string path = EditorUtility.SaveFilePanelInProject("保存prefab", obj.name + ".prefab", "prefab", "请选择要保存的prefab的位置",
						LastPath);
					if (!path.Equals(""))
					{
						LastPath = path.Substring(0, path.IndexOf(obj.name, StringComparison.Ordinal) - 1);
						PrefabUtility.CreatePrefab(path, obj, ReplacePrefabOptions.ConnectToPrefab);
						EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
					}
				}
			}
		}
	}
}
