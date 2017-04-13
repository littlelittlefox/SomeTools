//==============================================================
//  Create by fox at 2017-4-12
//==============================================================

using UnityEditor;
using UnityEngine;

namespace FoxTool
{
    [CustomPropertyDrawer(typeof(RenameAttribute))]
    public class RenameAttributeDrawer :PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            RenameAttribute attr = (RenameAttribute)base.attribute;
            label.text = attr.Name;
            EditorGUI.PropertyField(position, property, label);
        }
    }
}
