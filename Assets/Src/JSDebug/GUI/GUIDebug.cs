using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GUIDebug
{

    public static Line2DRender GetLineRender()
    {
        Line2DRender lineRender = new Line2DRender();
        lineRender.Uid = GetRenderUid();
        lineRender.Init();

        return lineRender;

    }

    private static int _UID = 0;
    private static int GetRenderUid()
    {
        return ++_UID;
    }
}
