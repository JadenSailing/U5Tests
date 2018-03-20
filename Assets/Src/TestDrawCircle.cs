using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TestDrawCircle : MonoBehaviour {
    public List<GameObject> polyPoints;

    private List<Vector3> _polyVertex = new List<Vector3>();

    private MeshFilter _meshFilter;
    private Mesh _mesh;
    private MeshRenderer _meshRender;

    public float LineWidth = 0.02f;

    public int ChildNum = 180;

    public float Radius = 2;

    private GameObject _lineObj;

	// Use this for initialization
	void Start () {

        this.AddLineRender();
	}

    private void AddLineRender()
    {
        _lineObj = new GameObject("TestDrawLine");
        _meshFilter = _lineObj.AddComponent<MeshFilter>();
        _meshRender = _lineObj.AddComponent<MeshRenderer>();

        _mesh = new Mesh();
        _meshFilter.mesh = _mesh;

        //设置材质 这里只需要顶点色即可
        _meshRender.material = new Material(Shader.Find("Jaden/VertexColor"));
    }

    private void DrawPolygon()
    {
        _polyVertex.Clear();
        for (int i = 0; i < polyPoints.Count + 1; i++)
        {
            Vector3 ptPos = polyPoints[i % polyPoints.Count].transform.localPosition;
            ptPos.z = 0;
            _polyVertex.Add(ptPos);
        }

        _mesh.Clear();

        Vector3 ccenter = _polyVertex[0];
        float radius = Radius;
        circle_center(_polyVertex, out ccenter, out radius);

        //顶点
        Vector3[] vertices = new Vector3[ChildNum * 2];
        for (int i = 0; i < ChildNum; i++)
        {
            int verIndex = i * 2;
            float nx = radius * Mathf.Cos(2 * Mathf.PI / 180 * i) + ccenter.x;
            float ny = radius * Mathf.Sin(2 * Mathf.PI / 180 * i) + ccenter.y;
            float fx = (radius + LineWidth ) * Mathf.Cos(2 * Mathf.PI / 180 * i) + ccenter.x;
            float fy = (radius + LineWidth) * Mathf.Sin(2 * Mathf.PI / 180 * i) + ccenter.y;
            vertices[verIndex + 0] = new Vector3(nx, ny, ccenter.z);
            vertices[verIndex + 1] = new Vector3(fx, fy, ccenter.z);
        }
        _mesh.vertices = vertices;

        //三角形
        int[] triangles = new int[ChildNum * 6];
        for (int i = 0; i < ChildNum; i++)
        {
            int triIndex = i * 6;
            int verIndex = i * 2;
            int n1 = verIndex;
            int f1 = verIndex + 1;
            int n2 = 0;
            int f2 = 1;
            if(i < ChildNum - 1)
            {
                n2 = verIndex + 2;
                f2 = verIndex + 3;
            }
            triangles[triIndex + 0] = n1;
            triangles[triIndex + 1] = f1;
            triangles[triIndex + 2] = f2;

            triangles[triIndex + 3] = n1;
            triangles[triIndex + 4] = f2;
            triangles[triIndex + 5] = n2;
        }
        _mesh.triangles = triangles;

        //uv
        Vector2[] uvs = new Vector2[ChildNum * 2];
        for (int i = 0; i < ChildNum; i++)
        {
            int uvIndex = i * 2;
            uvs[uvIndex + 0] = new Vector2(0, 0);
            uvs[uvIndex + 1] = new Vector2(1, 1);
        }
        _mesh.uv = uvs;

        //color
        Color32[] colors = new Color32[ChildNum * 2];
        Color32 green = new Color32(0, 255, 0, 255);
        for (int i = 0; i < ChildNum; i++)
        {
            int colorIndex = i * 2;
            colors[colorIndex + 0] = green;
            colors[colorIndex + 1] = green;
        }
        _mesh.colors32 = colors;
    }
	
	// Update is called once per frame
	void Update () {
        this.DrawPolygon();
	}

    ///////////////////////////////////////////  
    //求三角形外接圆圆心坐标  
    ///////////////////////////////////////////  
    public void circle_center(List<Vector3> points, out Vector3 center, out float radius)
    {
        float x1, x2, x3, y1, y2, y3;
        float x = 0;
        float y = 0;

        x1 = points[0].x;
        x2 = points[1].x;
        x3 = points[2].x;
        y1 = points[0].y;
        y2 = points[1].y;
        y3 = points[2].y;

        x = ((y2 - y1) * (y3 * y3 - y1 * y1 + x3 * x3 - x1 * x1) - (y3 - y1) * (y2 * y2 - y1 * y1 + x2 * x2 - x1 * x1)) / (2 * (x3 - x1) * (y2 - y1) - 2 * ((x2 - x1) * (y3 - y1)));
        y = ((x2 - x1) * (x3 * x3 - x1 * x1 + y3 * y3 - y1 * y1) - (x3 - x1) * (x2 * x2 - x1 * x1 + y2 * y2 - y1 * y1)) / (2 * (y3 - y1) * (x2 - x1) - 2 * ((y2 - y1) * (x3 - x1)));

        center = new Vector3();
        center.x = x;
        center.y = y;
        center.z = points[0].z;

        radius = Mathf.Sqrt((points[0].x - x) * (points[0].x - x) + (points[0].y - y) * (points[0].y - y));

    }
}
