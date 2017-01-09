using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class JSEditor : Editor
{

    #region 修改UILabel为2倍清晰
    //Ctrl-%,Shift-#,Alt-&
    [MenuItem("GameObject/修改Label &v", false, 12)]
    private static void ParseUILabel()
    {
        UILabel label = Selection.activeGameObject.GetComponent<UILabel>();
        if (label == null)
        {
            return;
        }
        if (label.transform.localScale.x == 0.5f)
        {
            UnityEngine.Debug.Log("当前组件已经是0.5scale:" + label.name);
            return;
        }

        //涉及Undo操作
        Undo.RecordObjects(new UnityEngine.Object[] { label.transform, label }, "changelabel" + label.name);

        label.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        label.width = label.width * 2;
        label.height = label.height * 2;
        label.fontSize = label.fontSize * 2;
    }

    [MenuItem("GameObject/修改Label &v", true)]
    private static bool ParseUILabelValidation()
    {
        if (Selection.activeGameObject == null)
        {
            return false;
        }
        if (Selection.activeGameObject.GetComponent<UILabel>() == null)
        {
            return false;
        }
        return true;
    }

    //Ctrl-%,Shift-#,Alt-&
    [MenuItem("GameObject/修改Label(全部) %&v", false, 12)]
    private static void ParseUILabelAll()
    {
        List<UILabel> list = new List<UILabel>();
        Selection.activeGameObject.GetComponentsInChildren<UILabel>(true, list);

        UnityEngine.Object[] objs = null;

        List<UnityEngine.Object> objList = new List<UnityEngine.Object>();

        List<UILabel> validList = new List<UILabel>();

        for (int i = 0; i < list.Count; i++)
        {
            UILabel label = list[i];
            if (label == null)
            {
                continue;
            }
            if (label.trueTypeFont != null)
            {
                if (label.trueTypeFont.name == "SIMLI") //千姐：隶书暂时不做处理
                {
                    continue;
                }
            }

            if (label.transform.localScale.x == 0.5f)
            {
                UnityEngine.Debug.Log("当前组件已经是0.5scale:" + label.name);
                continue;
            }

            validList.Add(label);
            objList.Add(label.transform);
            objList.Add(label);
        }

        objs = objList.ToArray();
        Undo.RecordObjects(objs, "changelabel");

        for (int i = 0; i < validList.Count; i++)
        {
            UILabel label = validList[i];
            label.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            label.width = label.width * 2;
            label.height = label.height * 2;
            label.fontSize = label.fontSize * 2;
        }
    }
    #endregion 修改UI为2倍清晰
}