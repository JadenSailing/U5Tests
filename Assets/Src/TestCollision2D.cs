using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestCollision2D : MonoBehaviour {

    private Line2DRender _lineRender;

    private Line2DRender _movingLineRender;

	// Use this for initialization
	void Start () {

        _lineRender = GUIDebug.GetLineRender();
        _lineRender.PointList = this.GetPointList();
        _lineRender.Render();

        _movingLineRender = GUIDebug.GetLineRender();
        SetState(0);
	}

    private int _state = 0;
    void OnGUI()
    {
        if(GUI.Button(new Rect(0, 0, 200, 100), "点击切换"))
        {
            SetState(1 - _state);
        }
    }

    private void SetState(int state)
    {
        _state = state;
        _movingLineRender.RenderObj.SetActive(_state == 1);
    }
	
	// Update is called once per frame
	void Update () {

        if(_state == 0)
        {
            Vector2[] polygon = this.GetPolygonPos(_lineRender);
            Vector2 targetPos = this.GetMousePos2D();
            if (HitTestUtil.HitTest(targetPos, polygon))
            {
                _lineRender.VertexColor32 = GUIColor32.red;
            }
            else
            {
                _lineRender.VertexColor32 = GUIColor32.green;
            }
            _lineRender.Render();
        }
        else
        {
            _movingLineRender.PointList = this.GetMovingPointList();

            Vector2[] polygon = this.GetPolygonPos(_lineRender);
            Vector2[] movingPolygon = this.GetPolygonPos(_movingLineRender);
            if(HitTestUtil.HitTest(polygon, movingPolygon))
            {
                _lineRender.VertexColor32 = GUIColor32.red;
                _movingLineRender.VertexColor32 = GUIColor32.red;
            }
            else
            {
                _lineRender.VertexColor32 = GUIColor32.green;
                _movingLineRender.VertexColor32 = GUIColor32.green;
            }
            _lineRender.Render();
            _movingLineRender.Render();
        }
        
	}
    private List<Vector3> GetPointList()
    {
        List<Vector3> pointList = new List<Vector3>();
        pointList.Add(new Vector3(-4, -4, 0));
        pointList.Add(new Vector3(-4, 0, 0));
        pointList.Add(new Vector3(0, 4, 0));
        pointList.Add(new Vector3(4, 0, 0));
        pointList.Add(new Vector3(4, -4, 0));
        pointList.Add(new Vector3(-4, -4, 0));
        return pointList;
    }

    private List<Vector3> GetMovingPointList()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0;

        List<Vector3> pointList = new List<Vector3>();
        pointList.Add(new Vector3(-2, 0, 0) + worldPos);
        pointList.Add(new Vector3(0, 2, 0) + worldPos);
        pointList.Add(new Vector3(2, 0, 0) + worldPos);
        pointList.Add(new Vector3(0, -2, 0) + worldPos);
        pointList.Add(new Vector3(-2, 0, 0) + worldPos);
        return pointList;
    }


    private Vector2 GetMousePos2D()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 targetPos = new Vector2(worldPos.x, worldPos.y);

        return targetPos;
    }

    private Vector2[] GetPolygonPos(Line2DRender lineRender)
    {
        Vector2[] polygon = new Vector2[lineRender.PointList.Count - 1];
        for (int i = 0; i < lineRender.PointList.Count - 1; i++)
        {
            polygon[i] = new Vector2(lineRender.PointList[i].x, lineRender.PointList[i].y);
        }
        return polygon;
    }
}
