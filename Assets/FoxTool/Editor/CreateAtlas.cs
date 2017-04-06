//==============================================================
//  Create by fox at 2017/3/19 22:38:19
//==============================================================

using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace FoxTool {
	public class CreateAtlas
	{
		public const string MenuItemName = "Assets/CreateAtlas";

		[MenuItem(MenuItemName, false, 0)]
		public static void Create()
		{
			ScriptableObject atlas = ScriptableObject.CreateInstance<UIAtlas>();

			if (!atlas)
			{
				Debug.LogError("UIAtlas Not Found");
				return;
			}

			Object[] arr = Selection.GetFiltered(typeof (Object), SelectionMode.TopLevel);
			//StringComparison.Ordinal 使用序号使用规则比较字符串
			string path = AssetDatabase.GetAssetPath(arr[0]) + "/Atlas.asset";
			AssetDatabase.CreateAsset(atlas, path);
			AssetDatabase.Refresh();
		}
	}
}
