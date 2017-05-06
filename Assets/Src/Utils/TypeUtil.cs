using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

/// <summary>
/// TypeUtil
/// </summary>
public class TypeUtil
{
    /// <summary>
    /// 打印public属性(get方法) 如public int a{get {return1}}； public static int b{get{reurn 2}}；
    /// </summary>
    /// <param name="inst"></param>
    /// <returns></returns>
    public static string GetPropertyInfo(object inst)
    {
        Type type = inst.GetType();
        string log = "";
        //静态属性值
        PropertyInfo[] infos = type.GetProperties();
        for (int i = 0; i < infos.Length; i++)
        {
            PropertyInfo info = infos[i];
            if(info.CanRead)
            {
                log += type.Name + "." + info.Name + " = " + info.GetValue(inst, null) + "\n";
            }
        }

        return log;
    }

    /// <summary>
    /// 打印public字段(成员字段) 如public int a = 1； public static int b = 2；
    /// </summary>
    /// <param name="inst"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 打印成员 可以自定义类型 如是否公开 是否继承等
    /// </summary>
    /// <param name="inst"></param>
    /// <returns></returns>
    public static string GetMemberInfo(object inst)
    {
        Type type = inst.GetType();
        string log = "";
        //静态属性值
        MemberInfo[] infos = type.GetMembers();
        for (int i = 0; i < infos.Length; i++)
        {
            MemberInfo info = infos[i];
            log += type.Name + "." + info.Name  + "\n";
        }

        return log;
    }
}


