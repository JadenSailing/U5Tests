using UnityEngine;
using System.Collections;

public class TestShaderCullingPass : MonoBehaviour {

    private float _startX = -4.0f;
    private float _maxX = 4.0f;
    private float _speed = 0.03f;
    private float _currentX = 0.0f;

	// Use this for initialization
	void Start () {
        Debug.Log("Frame:" + Application.targetFrameRate);
        _currentX = _startX;
	}
	
	// Update is called once per frame
	void Update () {
        _currentX += _speed;
        if (_currentX > _maxX)
        {
            _currentX = _startX;
        }
        Vector3 pos = this.transform.localPosition;
        pos.x = _currentX;
        this.transform.localPosition = pos;
	}
}
