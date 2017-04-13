//==============================================================
//  Create by fox at 2017-4-12
//==============================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace FoxTool
{
    //参考 雨松MOMO http://www.xuanyusong.com/archives/4213
    [CustomPropertyDrawer(typeof(EnumLabelAttribute))]
    public class EnumLabelAttributeDrawer:PropertyDrawer
    {
        private Dictionary<string, string> customEnumNames = new Dictionary<string, string>();

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SetUpCustomEnumNames(property, property.enumNames);

            EnumLabelAttribute attr = (EnumLabelAttribute) attribute;

            if (property.propertyType == SerializedPropertyType.Enum)
            {
                EditorGUI.BeginChangeCheck();
                string[] displayedOptions = property.enumNames
                        .Where(enumName => customEnumNames.ContainsKey(enumName))
                        .Select<string, string>(enumName => customEnumNames[enumName])
                        .ToArray();
                EditorGUI.Popup(position, attr.Name, 0, displayedOptions);
            }
        }

        public void SetUpCustomEnumNames(SerializedProperty property, string[] enumNames)
        {
            object[] customAttributes = fieldInfo.GetCustomAttributes(typeof(EnumLabelAttribute), false);
            foreach (EnumLabelAttribute customAttribute in customAttributes)
            {
                Type enumType = fieldInfo.FieldType;

                foreach (string enumName in enumNames)
                {
                    FieldInfo field = enumType.GetField(enumName);
                    if (field == null) continue;
                    EnumLabelAttribute[] attrs = (EnumLabelAttribute[])field.GetCustomAttributes(customAttribute.GetType(), false);

                    if (!customEnumNames.ContainsKey(enumName))
                    {
                        foreach (EnumLabelAttribute labelAttribute in attrs)
                        {
                            customEnumNames.Add(enumName, labelAttribute.Name);
                        }
                    }
                }
            }
        }
    }
}

