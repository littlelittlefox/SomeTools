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

		public void Add1() {
			Debug.Log("Add");
			EventManager.AddEventListener(EventEnum.Log, TestLog1);
		}

		private void TestLog1(object sender, EventArgs e)
		{
			Debug.Log("I'm another log");
		}

		private void TestLog(object sender, EventArgs e)
		{
			Debug.Log("Hahaha");
			Debug.Log(((EventHandleArgs.TestEventArg)e).Index.ToString());
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
			EventManager.RemoveEventListener(EventEnum.Log, TestLog);
		}
	}
}
