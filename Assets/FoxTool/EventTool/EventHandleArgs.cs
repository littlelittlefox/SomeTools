//==============================================================
//  Create by fox at 2017/4/7 11:41:39
//==============================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoxTool{
	public class EventHandleArgs {
		public class TestEventArg : EventArgs {
			public int Index;

			public TestEventArg(int index) {
				this.Index = index;
			}
		}
	}
}
