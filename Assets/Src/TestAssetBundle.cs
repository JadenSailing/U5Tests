using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TestAssetBundle : MonoBehaviour {

    public GameObject UIRoot;

	// Use this for initialization
	void Start () {

        /*
        AssetBundle ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/Scenes/" + "Test.Scene");
        SceneManager.LoadScene("TestAssetBundleScene1");
        */

        //加载UI
        AssetBundle fontAB = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/TestAB/" + "font.ab");
        AssetBundle iconAB = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/TestAB/" + "icon.ab");

        AssetBundle uiAB = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/TestAB/" + "testabpanel3.ab");
        string assetName = "TestAbpanel3";
        GameObject prefab = uiAB.LoadAsset(assetName) as GameObject;

        GameObject obj = GameObject.Instantiate(prefab);
        this.Add2UIRoot(obj);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Add2UIRoot(GameObject obj)
    {
        obj.transform.parent = UIRoot.transform;
        obj.transform.localScale = Vector3.one;
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;
    }
}
