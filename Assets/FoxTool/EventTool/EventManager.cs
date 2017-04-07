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
			if (EventFuncs.ContainsKey(e))
			{
				EventFuncs[e] += func;
			}
			else
			{
				EventFuncs.Add(e, func);
			}
		}

		public static void SendEvent(EventEnum e, object sender = null, EventArgs arg = null)
		{
			if (EventFuncs.ContainsKey(e))
			{
				foreach (var @delegate in EventFuncs[e].GetInvocationList())
				{
					var handler = (EventHandler) @delegate;
					handler.BeginInvoke(sender, arg, new AsyncCallback((a) =>
					{
						try {
							handler.EndInvoke(a);
						} catch (Exception ex) {
							Debug.LogError(ex);
							throw new Exception(ex.Message);
						}
					}), null);
				}
			}
			else
			{
				Debug.LogError(e + " is not rigister!");
			}
		}

		public static void RemoveEventListener(EventEnum e, EventHandler func)
		{
			if (EventFuncs.ContainsKey(e))
			{
				// ReSharper disable once DelegateSubtraction
				EventFuncs[e] -= func;
				if (EventFuncs[e] == null)
					EventFuncs.Remove(e);
			}
			else
			{
				Debug.LogError(e + " is not rigister!");
			}
		}
	}
}
