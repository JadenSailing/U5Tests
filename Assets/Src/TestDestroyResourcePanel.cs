using UnityEngine;
using System.Collections;

/// <summary>
/// 测试Rt资源的卸载
/// </summary>
public class TestDestroyResourcePanel : MonoBehaviour {

    public GameObject UIRoot;

    public UnityEngine.Camera uiCamera;

    public UITexture textureRT;

    private RenderTexture _rt;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(UIRoot);
	}

    void OnGUI()
    {
        if(GUI.Button(new Rect(0, 0, 200, 100), "创建RT"))
        {
            RenderRT();
        }
        if (GUI.Button(new Rect(0, 100, 200, 100), "销毁Texture"))
        {
            DestroyTexture();
        }
        if (GUI.Button(new Rect(0, 200, 200, 100), "切换场景"))
        {
            LoadNextScene();
        }
        if (GUI.Button(new Rect(0, 300, 200, 100), "销毁RT"))
        {
            DestroyRenderTexture();
        }
        if (GUI.Button(new Rect(0, 400, 200, 100), "销毁RT置空texture.main"))
        {
            DestroyRenderTexture2();
        }
        if (GUI.Button(new Rect(0, 500, 200, 100), "UnLoadAll"))
        {
            UnLoadAll();
        }
    }

    /// <summary>
    /// 延迟渲染RT 并显示到屏幕
    /// </summary>
    private void RenderRT()
    {
        _rt = GetCurrentRt();
        textureRT.mainTexture = _rt;
    }

    /// <summary>
    /// 延迟销毁该资源
    /// </summary>
    private void DestroyTexture()
    {
        //RenderTexture.ReleaseTemporary(_rt); //TempBuffer必须调用这个才能置空引用

        _rt = null; //引用必须置空 才能销毁
        textureRT.mainTexture = null; //此处引用必须置空 才能销毁
        GameObject.Destroy(textureRT.gameObject);
    }

    /// <summary>
    /// 切换场景资源
    /// 切换场景后 无引用的资源会销毁
    /// </summary>
    private void LoadNextScene()
    {
        Application.LoadLevel("TestDestroyResource_Next");
    }

    /// <summary>
    /// 强制回收资源 引用不为空也可以销毁(_rt之前必须不能释放)
    /// </summary>
    private void DestroyRenderTexture()
    {
        //但是可能会导致引用该RT的地方出现各种问题 如引用到别的texture的显示异常
        GameObject.DestroyImmediate(_rt, true);
    }

    /// <summary>
    /// 强制回收资源 引用不为空也可以销毁
    /// 这里先置空mainTexture(但是保留_rt了引用)
    /// </summary>
    private void DestroyRenderTexture2()
    {
        textureRT.mainTexture = null;
        //但是可能会导致引用该RT的地方出现各种问题 如引用到别的texture的显示异常
        GameObject.DestroyImmediate(_rt, true);

        //下面会报错 MissingReferenceException: The object of type 'RenderTexture' has been destroyed but you are still trying to access it.
        //UnityEngine.Debug.Log("销毁资源后访问RT: width=" + _rt.width);

        //销毁资源后访问RT: ==Null? =True
        UnityEngine.Debug.Log("销毁资源后访问RT: ==Null? =" + (_rt == null).ToString());

        //销毁资源后访问RT: tostring=null
        UnityEngine.Debug.Log("销毁资源后访问RT: tostring=" + _rt.ToString());
    }

    /// <summary>
    /// UnloadAll后 所有无引用的资源都会销毁
    /// </summary>
    private void UnLoadAll()
    {
        Resources.UnloadUnusedAssets();
    }

    public RenderTexture GetCurrentRt()
    {
        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 16, RenderTextureFormat.ARGB32);

        //下面的方法会增加引用
        //RenderTexture rt = RenderTexture.GetTemporary(Screen.width, Screen.height, 16, RenderTextureFormat.ARGB32);

        uiCamera.targetTexture = rt;
        uiCamera.Render();
        uiCamera.targetTexture = null;
        return rt;
    }
}
