//==============================================================
//  Create by fox at 2017/3/18 22:49:41
//==============================================================

using UnityEngine;

namespace FoxTool
{
	public class Move : MonoBehaviour
	{
		public Vector3 Speed;

		private Transform _transform;

		void Awake()
		{
			_transform = transform;
		}

		void Update()
		{
			_transform.Translate(Speed);
		}
	}
}
