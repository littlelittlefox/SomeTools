//==============================================================
//  Create by fox at 2017/3/18 21:02:26
//==============================================================

using UnityEngine;

namespace FoxTool {
	public class ShowFPS : MonoBehaviour
	{
		float deltaTime = 0.0f;

		void Update() {
			deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
		}

		//来自官方示例 http://wiki.unity3d.com/index.php?title=FramesPerSecond
		void OnGUI()
		{
			float msec = deltaTime*1000.0f;
			float fps = 1.0f/deltaTime;

			int w = Screen.width, h = Screen.height;
			GUIStyle style = new GUIStyle();

			Rect rect = new Rect(-10, 10, w, h*2/100);
			style.alignment = TextAnchor.UpperRight;
			style.fontSize = 15;
			style.normal.textColor = fps < 15 ? Color.red : Color.green;
			string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
			GUI.Label(rect, text, style);
		}
	}
}
