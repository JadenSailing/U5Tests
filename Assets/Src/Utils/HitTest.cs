using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 碰撞检测
/// </summary>
public class HitTestUtil
{
    /// <summary>
    /// 点是否在多边形内部检测
    /// </summary>
    /// <param name="point"></param>
    /// <param name="polygon"></param>
    /// <returns></returns>
    public static bool HitTest(Vector2 point, Vector2[] polygon)
    {
        Vector2[] edges = new Vector2[polygon.Length];
        for (int i = 0; i < polygon.Length; i++)
        {
            if (i < polygon.Length - 1)
            {
                edges[i].x = -(polygon[i].y - polygon[i + 1].y);
                edges[i].y = polygon[i].x - polygon[i + 1].x;
            }
            else
            {
                edges[i].x = -(polygon[i].y - polygon[0].y);
                edges[i].y = polygon[i].x - polygon[0].x;
            }
        }

        Vector2[] pointArr = new Vector2[] { point };
        for (int i = 0; i < edges.Length; i++)
        {
            if (CompareProjection(edges[i], pointArr, polygon))
            {
                return false;
            }
        }

        return true;
    }



    /// <summary>
    /// 多边形碰撞检测
    /// </summary>
    /// <param name="A">多边形顶点集合 </param>
    /// <param name="B">多边形顶点集合 </param>
    /// <returns></returns>
    public static bool HitTest(Vector2[] A, Vector2[] B)
    {
        if (A.Length < 3 || B.Length < 3) return false;
        Vector2[] a1 = new Vector2[A.Length];
        for (int i = 0; i < A.Length; i++)
        {
            if (i < A.Length - 1)
            {
                a1[i].x = -(A[i].y - A[i + 1].y);
                a1[i].y = A[i].x - A[i + 1].x;
            }
            else
            {
                a1[i].x = -(A[i].y - A[0].y);
                a1[i].y = A[i].x - A[0].x;
            }
        }

        Vector2[] b1 = new Vector2[B.Length];
        for (int i = 0; i < B.Length; i++)
        {
            if (i < B.Length - 1)
            {
                b1[i].x = -(B[i].y - B[i + 1].y);
                b1[i].y = B[i].x - B[i + 1].x;
            }
            else
            {
                b1[i].x = -(B[i].y - B[0].y);
                b1[i].y = B[i].x - B[0].x;
            }
        }
        for (int i = 0; i < a1.Length; i++)
        {
            if (CompareProjection(a1[i], A, B)) return false;
        }

        for (int i = 0; i < b1.Length; i++)
        {
            if (CompareProjection(b1[i], A, B)) return false;
        }
        return true;
    }
    
    /// <summary>
    /// 向法线投影 比较AB数组是否有重叠
    /// </summary>
    /// <param name="normal"></param>
    /// <param name="A"></param>
    /// <param name="B"></param>
    /// <returns></returns>
    private static bool CompareProjection(Vector2 normal, Vector2[] A, Vector2[] B)
    {
        float[] projectionA = new float[A.Length];
        for (int i = 0; i < A.Length; i++)
        {
            projectionA[i] = normal.x * A[i].x + normal.y * A[i].y;
        }
        float[] projectionB = new float[B.Length];
        for (int i = 0; i < B.Length; i++)
        {
            projectionB[i] = normal.x * B[i].x + normal.y * B[i].y;
        }
        if ((Mathf.Max(projectionA) < Mathf.Min(projectionB)) || (Mathf.Min(projectionA) > Mathf.Max(projectionB)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}


