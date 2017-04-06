//==============================================================
//  Create by fox at 2017/3/19 22:42:23
//==============================================================

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace FoxTool {
	public class UIAtlas : ScriptableObject
	{
		public string TexturePath = "Assets/UI/Texture";
		public Sprite[] Sprites;

		private Dictionary<string, Sprite> _spriteDirectory;

		public Dictionary<string, Sprite> SpriteDirectory
		{
			get
			{
				if (_spriteDirectory == null)
					LoadSprites();
				return _spriteDirectory;
			}
		}

		public Sprite this[string spriteName] {
			get {
				return _spriteDirectory[spriteName];
			}
		}

		private void LoadSprites()
		{
			_spriteDirectory = new Dictionary<string, Sprite>();
			foreach (var sprite in Sprites)
			{
				_spriteDirectory[sprite.name] = sprite;
			}
		}

#if UNITY_EDITOR
		[ContextMenu("PackAtlas")]
		public void PackAtlas()
		{
			string path = TexturePath + "/" + name;

			if (Directory.Exists(path))
			{
				string[] files = Directory.GetFiles(path);
				Sprites = new Sprite[files.Length/2];
				for (int i = 0; i < files.Length; i++)
				{
					if (!files[i].Contains(".meta"))
					{
						TextureImporter assetImporter = AssetImporter.GetAtPath(files[i]) as TextureImporter;
						if (assetImporter != null)
						{
							assetImporter.spritePackingTag = name;
							assetImporter.SaveAndReimport();
							Sprite sprite = (Sprite) AssetDatabase.LoadAssetAtPath(files[i], typeof (Sprite));
							Sprites[i/2] = sprite;
						}
					}
				}
			}
			else
			{
				Debug.LogError(path + " Not Found");
			}
		}
#endif
	}
}
