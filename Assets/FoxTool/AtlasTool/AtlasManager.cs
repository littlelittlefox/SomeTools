//==============================================================
//  Create by fox at 2017/3/19 23:57:55
//==============================================================

using UnityEngine;

namespace FoxTool
{
	public class AtlasManager
	{
		public const string AtlasPath = "Atlas/";

		public static Sprite GetSprite(string atlasName,string spriteName)
		{
			Sprite sprite = null;

			UIAtlas atlas = Resources.Load<UIAtlas>(AtlasPath + atlasName);
			if (atlas != null)
			{
				if (atlas.SpriteDirectory.ContainsKey(spriteName))
				{
					sprite = atlas[spriteName];
				}
				else
				{
					Debug.LogError(spriteName + " Not Found!");
				}
			}
			else
			{
				Debug.LogError(atlasName + " Not Found!");
			}

			return sprite;
		}
	}
}
