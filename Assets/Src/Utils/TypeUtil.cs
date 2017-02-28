using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

/// <summary>
/// 碰撞检测
/// </summary>
public class TypeUtil
{
    public static string GetStaticInfo(Type type)
    {
        string log = "";
        //静态属性值
        PropertyInfo[] infos = type.GetProperties();
        for (int i = 0; i < infos.Length; i++)
        {
            PropertyInfo info = infos[i];
            log += (type.Name + "." + infos[i].Name + " = " + infos[i].GetValue(null, null)) + "\n";
        }

        return log;
    }

    public static string GetFieldInfo(object inst)
    {
        Type type = inst.GetType();
        string log = "";
        //静态属性值
        FieldInfo[] infos = type.GetFields();
        for (int i = 0; i < infos.Length; i++)
        {
            FieldInfo info = infos[i];
            log += type.Name + "." + info.Name + " = " + info.GetValue(inst) + "\n";
        }

        return log;
    }
}


