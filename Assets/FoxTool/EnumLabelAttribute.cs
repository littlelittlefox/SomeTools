//==============================================================
//  Create by fox at 2017-4-12
//==============================================================

using UnityEngine;

namespace FoxTool
{
    public class EnumLabelAttribute : PropertyAttribute
    {
        public string Name;

        public EnumLabelAttribute(string name)
        {
            this.Name = name;
        }
    }
}
