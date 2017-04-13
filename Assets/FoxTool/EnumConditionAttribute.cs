//==============================================================
//  Create by fox at 2017-4-13
//==============================================================

using UnityEngine;

namespace FoxTool
{
    public class EnumConditionAttribute : PropertyAttribute
    {
        public string EnumCondition;
        public bool Show;

        /// <summary>
        /// 根据枚举类型来判定是否显示此变量
        /// </summary>
        /// <param name="con"> 枚举变量名.A|B|C </param>
        /// <param name="show">是否显示</param>
        public EnumConditionAttribute(string con, bool show = true)
        {
            this.EnumCondition = con;
            this.Show = show;
        }
    }
}
