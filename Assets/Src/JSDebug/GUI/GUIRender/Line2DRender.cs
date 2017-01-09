using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class Line2DRender : AbstractGUIRender
{
    public enum LinePlaneType
    {
        XY,
        YZ,
        XZ
    }

    private List<Vector3> _pointList = null;

    private float _lineWidth = 0.02f;

    private LinePlaneType _planeType = LinePlaneType.XY;

    /// <summary>
    /// 设置划线数据
    /// </summary>
    /// <param name="pointList"></param>
    public List<Vector3> PointList
    {
        set
        {
            _pointList = value;
        }
        get
        {
            return _pointList;
        }
    }

    public float LineWidth
    {
        set
        {
            _lineWidth = value;
        }
    }

    public LinePlaneType PlaneType
    {
        set
        {
            _planeType = value;
        }
    }

    protected override string GetRenderName()
    {
        return "LineRender" + _uid;
    }

    protected override void PreInit()
    {
        base.PreInit();
        _shader = Shader.Find("Jaden/VertexColor");

    }

    protected override void OnRender()
    {
        if(_pointList == null || _pointList.Count < 2)
        {
            return;
        }

        base.OnRender();


        int lineNum = _pointList.Count - 1;
        //顶点
        Vector3[] vertices = new Vector3[lineNum * 4];
        for (int i = 0; i < lineNum; i++)
        {
            int verIndex = i * 4;
            Vector3 delta = _pointList[i + 1] - _pointList[i];
            delta = delta.normalized;
            Vector3 normal = Vector3.zero;
            switch(_planeType)
            {
                case LinePlaneType.XY:
                    normal = new Vector3(delta.y, -delta.x, 0);
                    break;
                case LinePlaneType.YZ:
                    normal = new Vector3(0, -delta.z, delta.y);
                    break;
                case LinePlaneType.XZ:
                    normal = new Vector3(delta.z, 0, -delta.x);
                    break;
            }
            vertices[verIndex + 0] = _pointList[i] + normal * _lineWidth;
            vertices[verIndex + 1] = _pointList[i] - normal * _lineWidth;
            vertices[verIndex + 2] = _pointList[i + 1] + normal * _lineWidth;
            vertices[verIndex + 3] = _pointList[i + 1] - normal * _lineWidth;
        }
        _mesh.vertices = vertices;

        //三角形
        int[] triangles = new int[lineNum * 6];
        for (int i = 0; i < lineNum; i++)
        {
            int triIndex = i * 6;
            int verIndex = i * 4;
            triangles[triIndex + 0] = verIndex;
            triangles[triIndex + 1] = verIndex + 1;
            triangles[triIndex + 2] = verIndex + 2;
            triangles[triIndex + 3] = verIndex + 1;
            triangles[triIndex + 4] = verIndex + 3;
            triangles[triIndex + 5] = verIndex + 2;
        }
        _mesh.triangles = triangles;

        //uv
        Vector2[] uvs = new Vector2[lineNum * 4];
        for (int i = 0; i < lineNum; i++)
        {
            int uvIndex = i * 4;
            uvs[uvIndex + 0] = new Vector2(0, 0);
            uvs[uvIndex + 1] = new Vector2(0, 1);
            uvs[uvIndex + 2] = new Vector2(1, 1);
            uvs[uvIndex + 3] = new Vector2(1, 0);
        }
        _mesh.uv = uvs;

        //color
        Color32[] colors = new Color32[lineNum * 4];
        for (int i = 0; i < lineNum; i++)
        {
            int colorIndex = i * 4;
            colors[colorIndex + 0] = _vertexColor32;
            colors[colorIndex + 1] = _vertexColor32;
            colors[colorIndex + 2] = _vertexColor32;
            colors[colorIndex + 3] = _vertexColor32;
        }
        _mesh.colors32 = colors;

    }

}
