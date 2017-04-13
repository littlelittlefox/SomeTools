//==============================================================
//  Create by fox at 2017-4-12
//==============================================================

using UnityEngine;

namespace FoxTool
{
    public class RenameAttribute : PropertyAttribute
    {
        public string Name;

        public RenameAttribute(string name)
        {
            this.Name = name;
        }
    }
}
