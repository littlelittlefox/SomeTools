//==============================================================
//  Create by fox at 2017/5/14 11:07:53
//==============================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(BoolConditionAttribute))]
// ReSharper disable once CheckNamespace
public class BoolConditionAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        BoolConditionAttribute attr = (BoolConditionAttribute) base.attribute;
        bool enable = CheckCondition(attr, property);
        if ((attr.Show && enable) || (!attr.Show && !enable))
        {
            EditorGUI.PropertyField(position, property, label);
        }
    }

    public bool CheckCondition(BoolConditionAttribute attr, SerializedProperty property)
    {
        bool enable = false;
        SerializedProperty value = property.serializedObject.FindProperty(attr.BoolCondition);
        enable = value != null && value.boolValue;
        return enable;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        BoolConditionAttribute attr = (BoolConditionAttribute)base.attribute;
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
