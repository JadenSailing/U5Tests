using UnityEngine;
using System.Collections;

/// <summary>
/// 涉及万向锁问题...
/// Unity里的欧拉角旋转顺序 Y-X-Z
/// Y轴始终沿当前空间坐标系的方向
/// X轴受Y轴偏移影响
/// Z轴受XY轴偏移影响
/// X轴的欧拉角范围应为-90~90
/// eg.当X=90时 转动Y轴或者Z轴会使物体沿同一个轴向转动
/// </summary>

public class TestLocalRotation : MonoBehaviour {

    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;

    private Vector3 eulerAngle1;
    private Vector3 eulerAngle2;
    private Vector3 eulerAngle3;
	// Use this for initialization
	void Start () {
        Application.targetFrameRate = 30;
        eulerAngle1 = cube1.transform.localEulerAngles;
        eulerAngle2 = cube2.transform.localEulerAngles;
        eulerAngle3 = cube3.transform.localEulerAngles;
	}

    void OnGUI()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
        if(eulerAngle1.x == 90.0f)
        {
            eulerAngle1.x = -90;
        }
        eulerAngle1.x = eulerAngle1.x + 1.0f;
        cube1.transform.localEulerAngles = eulerAngle1;

        eulerAngle2.y = eulerAngle2.y + 1.0f;
        cube2.transform.localEulerAngles = eulerAngle2;

        eulerAngle3.z = eulerAngle3.z + 1.0f;
        cube3.transform.localEulerAngles = eulerAngle3;
	}
}
