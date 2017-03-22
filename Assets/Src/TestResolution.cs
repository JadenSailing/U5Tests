using UnityEngine;
using System.Collections;

/// <summary>
/// Android下设置多少 就是多少
/// </summary>
public class TestResolution : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Screen.SetResolution(960, 540, true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        int width = Screen.width;
        int height = Screen.height;
        int resWid = Screen.currentResolution.width;
        int resHeight = Screen.currentResolution.height;
        GUI.Label(new Rect(100, 100, 200, 50),"分辨率宽度=" + width);
        GUI.Label(new Rect(100, 150, 200, 50), "分辨率高度=" + height);
        GUI.Label(new Rect(100, 200, 200, 50), "Resolution宽度=" + resWid);
        GUI.Label(new Rect(100, 250, 200, 50), "Resolution高度=" + resHeight);
    }
}
