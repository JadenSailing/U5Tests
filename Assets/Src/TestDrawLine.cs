using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TestDrawLine : MonoBehaviour {
    public List<GameObject> polyPoints;

    private List<Vector3> _polyVertex = new List<Vector3>();

    private MeshFilter _meshFilter;
    private Mesh _mesh;
    private MeshRenderer _meshRender;

    public float LineWidth = 0.02f;

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

        int lineNum = _polyVertex.Count - 1;
        //顶点
        Vector3[] vertices = new Vector3[lineNum * 4];
        for (int i = 0; i < lineNum; i++)
        {
            int verIndex = i * 4;
            Vector3 delta = _polyVertex[i + 1] - _polyVertex[i];
            delta = delta.normalized;
            Vector3 normal = new Vector3(delta.y, -delta.x, 0);
            vertices[verIndex + 0] = _polyVertex[i] + normal * LineWidth;
            vertices[verIndex + 1] = _polyVertex[i] - normal * LineWidth;
            vertices[verIndex + 2] = _polyVertex[i + 1] + normal * LineWidth;
            vertices[verIndex + 3] = _polyVertex[i + 1] - normal * LineWidth;
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
        Color32 green = new Color32(0, 255, 0, 255);
        for (int i = 0; i < lineNum; i++)
        {
            int colorIndex = i * 4;
            colors[colorIndex + 0] = green;
            colors[colorIndex + 1] = green;
            colors[colorIndex + 2] = green;
            colors[colorIndex + 3] = green;
        }
        _mesh.colors32 = colors;
    }
	
	// Update is called once per frame
	void Update () {
        this.DrawPolygon();
	}
}
