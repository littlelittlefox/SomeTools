//==============================================================
//  Create by fox at 2017-3-18
//==============================================================

using UnityEditor;
using UnityEngine;

namespace FoxTool
{
	public class DeleteAllData
	{
		public const string MenuItemName = "FoxTool/DeleteAllData";

		[MenuItem(MenuItemName)]
		public static void ClearAllData()
		{
			PlayerPrefs.DeleteAll();
		}
	}
}
