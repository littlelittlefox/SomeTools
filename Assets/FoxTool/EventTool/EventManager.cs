//==============================================================
//  Create by fox at 2017/4/6 18:10:33
//==============================================================

using System;
using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace FoxTool {
	public class EventManager
	{
		private static readonly Dictionary<EventEnum, EventHandler> EventFuncs = new Dictionary<EventEnum, EventHandler>();

		public static void AddEventListener(EventEnum e, EventHandler func) {
			if (func == null) {
				Debug.LogError("不能添加空事件");
				return;
			}
			EventFuncs.Add(e, func);
		}

		public static void SendEvent(EventEnum e, object sender = null, EventArgs arg = null)
		{
			if (EventFuncs.ContainsKey(e))
			{
				EventFuncs[e](sender, arg);
			}
			else
			{
				Debug.LogError(e + " is not rigister!");
			}
		}

		public static void RemoveEventListener(EventEnum e)
		{
			if (EventFuncs.ContainsKey(e))
			{
				// ReSharper disable once DelegateSubtraction
				EventFuncs[e] -= EventFuncs[e];
				EventFuncs.Remove(e);
			}
			else
			{
				Debug.LogError(e + " is not rigister!");
			}
		}
	}
}
