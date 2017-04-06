//==============================================================
//  Create by fox at 2017/4/6
//==============================================================

using UnityEditor;
using UnityEngine;

public class FastApply {
	public const string MenuItemName = "FoxTool/FastApply";

	[InitializeOnLoadMethod]
	public static void Init() {
		Register();
	}

	public static bool IsShow {
		get { return PlayerPrefs.GetInt("FastApply", 0) != 0; }

		set { PlayerPrefs.SetInt("FastApply", value ? 1 : 0); } 
	}

	[MenuItem(MenuItemName)]
	public static void ApplyFast() {
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

	public static void Register() {
		if (IsShow) {
			EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGui;
		} else {
			// ReSharper disable once DelegateSubtraction
			EditorApplication.hierarchyWindowItemOnGUI -= HierarchyWindowItemOnGui;
		}
	}

	private static void HierarchyWindowItemOnGui(int instanceID, Rect selectionRect) {
		GameObject obj = (GameObject)EditorUtility.InstanceIDToObject(instanceID);
		if (obj)
		{
			Object o = PrefabUtility.GetPrefabParent(obj);
            if (o != null)
			{
				GUIStyle style = new GUIStyle(GUI.skin.button) {fontSize = 9};
				if (GUI.Button(new Rect(selectionRect.x + selectionRect.width - 54, selectionRect.y, 50, 14), "apply", style))
				{
					PrefabUtility.ReplacePrefab(PrefabUtility.FindPrefabRoot(obj), o, ReplacePrefabOptions.ConnectToPrefab);
				}
			}
		}
	}
}
