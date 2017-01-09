using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class AbstractGUIRender
{
    protected int _uid = 0;

    protected GameObject _renderObj = null;

    protected MeshFilter _meshFilter = null;

    protected Mesh _mesh = null;

    protected Material _material = null;

    protected Shader _shader = null;

    protected MeshRenderer _meshRender = null;

    protected Vector3[] _vertices = null;

    protected int[] _triangles = null;

    protected Vector2[] uvs = null;

    protected Color32[] color32 = null;

    protected Color32 _vertexColor32 = GUIColor32.green;

    public AbstractGUIRender()
    {

    }

    public Color32 VertexColor32
    {
        set
        {
            _vertexColor32 = value;
        }
    }

    public void Init()
    {
        this.PreInit();
        this.OnInit();
    }

    public void Render()
    {
        this.OnRender();
    }

    protected virtual void PreInit()
    {

    }

    protected virtual void OnInit()
    {
        _renderObj = new GameObject(this.GetRenderName());

        _meshFilter = _renderObj.AddComponent<MeshFilter>();
        _meshRender = _renderObj.AddComponent<MeshRenderer>();

        _mesh = new Mesh();
        _meshFilter.mesh = _mesh;

        _material = new Material(_shader);
        _meshRender.material = _material;
    }

    protected virtual string GetRenderName()
    {
        return _uid.ToString();
    }

    protected virtual void OnRender()
    {
            
    }

    public int Uid
    {
        get
        {
            return _uid;
        }
        set
        {
            _uid = value;
        }
    }

    public GameObject RenderObj
    {
        get
        {
            return _renderObj;
        }
    }
}