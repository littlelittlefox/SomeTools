//==============================================================
//  Create by fox at 2017-4-13
//==============================================================

using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace FoxTool
{
    /// <summary>
    /// 参考 http://forum.china.unity3d.com/thread-17599-1-1.html
    /// </summary>
    [CustomPropertyDrawer(typeof(EnumConditionAttribute))]
    public class EnumConditionAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EnumConditionAttribute attr = (EnumConditionAttribute) base.attribute;
            bool enable = CheckCondition(attr, property);
            if ((attr.Show && enable)||(!attr.Show && !enable))
            {
                EditorGUI.PropertyField(position, property, label);
            }
        }

        private bool CheckCondition(EnumConditionAttribute attr, SerializedProperty property)
        {
            bool enabled = false;
            string[] con = attr.EnumCondition.Split('.');
            string[] cons = con[1].Split('|');
            //Look for the sourcefield within the object that the property belongs to
            SerializedProperty sourcePropertyValue = property.serializedObject.FindProperty(con[0]);
            if (sourcePropertyValue != null)
            {
                foreach (var str in cons)
                {                    
                    if (sourcePropertyValue.enumNames.Contains(str))
                    {
                        int index = Array.IndexOf(sourcePropertyValue.enumNames, str);
                        enabled = index == sourcePropertyValue.enumValueIndex;
                        if (enabled)
                        {
                            break;
                        }
                    }
                    else
                    {
                        Debug.LogError("Can not find " + str);
                    }
                }
            }
            else
            {
                Debug.LogError("Can not find " + con[0]);
            }


            return enabled;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            EnumConditionAttribute attr = (EnumConditionAttribute)base.attribute;
            bool enable = CheckCondition(attr, property);
            if ((attr.Show && enable) || (!attr.Show && !enable))
            {
                return EditorGUI.GetPropertyHeight(property);
            }
            else
            {
                return -EditorGUIUtility.standardVerticalSpacing;
            }
        }
    }
}
