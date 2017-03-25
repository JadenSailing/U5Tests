using UnityEngine;
using System.Collections;

/// <summary>
/// Android下设置多少 就是多少
/// </summary>
public class TestResolution : MonoBehaviour {

    private float dpi1;
    private float dpi2;

    private float _width;
    private float _height;
	// Use this for initialization
	void Start () {
        _width = Screen.width;
        _height = Screen.height;
        dpi1 = Screen.dpi;
        Screen.SetResolution(960, 540, true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        dpi2 = Screen.dpi;
        int width = Screen.width;
        int height = Screen.height;
        int resWid = Screen.currentResolution.width;
        int resHeight = Screen.currentResolution.height;
        float mousePosX = Input.mousePosition.x;
        float mousePosY = Input.mousePosition.y;
        float mousePosZ = Input.mousePosition.z;

        GUI.Label(new Rect(100, 0, 200, 50), "分辨率宽度1=" + _width);
        GUI.Label(new Rect(100, 50, 200, 50), "分辨率高度1=" + _height);

        GUI.Label(new Rect(100, 100, 200, 50),"分辨率宽度=" + width);
        GUI.Label(new Rect(100, 150, 200, 50), "分辨率高度=" + height);


        GUI.Label(new Rect(100, 200, 200, 50), "Resolution宽度=" + resWid);
        GUI.Label(new Rect(100, 250, 200, 50), "Resolution高度=" + resHeight);
        GUI.Label(new Rect(100, 300, 200, 50), "DPI Before=" + dpi1);
        GUI.Label(new Rect(100, 350, 200, 50), "DPI After=" + dpi2);

        GUI.Label(new Rect(100, 400, 200, 50), "pos" + mousePosX + "-" + mousePosY + "-" + mousePosZ);
    }
}
