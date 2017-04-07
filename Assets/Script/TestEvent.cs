//==============================================================
//  Create by fox at 2017/4/6 21:55:55
//==============================================================

using System;
using FoxTool;
using UnityEngine;

namespace Test {
	public class TestEvent : MonoBehaviour{

		public void Add()
		{
			Debug.Log("Add");
			EventManager.AddEventListener(EventEnum.Log, TestLog);
		}

		private void TestLog(object sender, EventArgs e)
		{
			Debug.Log("I'm a log " + (e == null ? "null" : ((EventHandleArgs.TestEventArg) e).Index.ToString()));
		}

		public void Send()
		{
			Debug.Log("Send");
			EventManager.SendEvent(EventEnum.Log);
		}

		public void Send(int i)
		{
			Debug.Log("Send : " + i);
			EventManager.SendEvent(EventEnum.Log,null,new EventHandleArgs.TestEventArg(i));
		}

		public void Remove()
		{
			Debug.Log("Remove");
			EventManager.RemoveEventListener(EventEnum.Log);
		}
	}
}
