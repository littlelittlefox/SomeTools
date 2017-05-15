//==============================================================
//  Create by fox at 2017/5/14 11:01:55
//==============================================================

using UnityEngine;

// ReSharper disable once CheckNamespace
public class BoolConditionAttribute : PropertyAttribute
{
    public string BoolCondition;
    public bool Show;

    public BoolConditionAttribute(string con, bool show)
    {
        this.BoolCondition = con;
        this.Show = show;
    }
}
