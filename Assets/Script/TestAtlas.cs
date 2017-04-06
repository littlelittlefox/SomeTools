//==============================================================
//  Create by fox at 2017/3/26 23:49:24
//==============================================================

using FoxTool;
using UnityEngine;
using UnityEngine.UI;

namespace Test
{
	public class TestAtlas :MonoBehaviour
	{
		public string AtlasName;
		public string SpriteName;
		public Image TestImage;

		void Start()
		{
			TestImage.sprite = AtlasManager.GetSprite(AtlasName, SpriteName);
		}
	}
}
