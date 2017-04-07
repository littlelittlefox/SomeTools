//==============================================================
//  Create by fox at 2017/4/7 22:03:01
//==============================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script {
	class Program {
		delegate void ZuoFanHandle();

		static void Main(string[] args) {
			cZuoFan mZuoFan = new cZuoFan();
			ZuoFanHandle ZuoFan = new ZuoFanHandle(mZuoFan.LaoPoZuoFan);
			mZuoFan.FanShuLe += new cZuoFan.FanShuLeHandle(mZuoFan.ChiFan);
			Console.Write("==================同步调用===================\r\n\r\n");
			ZuoFan.Invoke();
			Console.Write("我一直在看着老婆做饭,不用儿子叫,我也知道饭熟了\r\n\r\n");

			Console.Write("==================异步调用===================\r\n\r\n");
			ZuoFan.BeginInvoke(null, null);
			Console.Write("老婆先去做吧,我看会电视,还可以干点别的,儿子叫我再吃饭\r\n");
			Console.Read();

		}
	}

	class cZuoFan {
		public delegate void FanShuLeHandle();
		public event FanShuLeHandle FanShuLe;

		public void LaoPoZuoFan() {
			Console.Write("老婆去做饭\r\n");
			for (int i = 0; i <= 100; i = i + 10) {
				Console.Write(string.Format("老婆做饭完成了{0}%\r\n", i));
				System.Threading.Thread.Sleep(500);
				if (i == 100) {
					if (FanShuLe != null) {
						FanShuLe();
					}
				}
			}
		}
		public void ChiFan() {
			Console.Write("饭熟了,儿子叫我吃饭了\r\n");
		}
	}
}
