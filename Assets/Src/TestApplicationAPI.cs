using UnityEngine;
using System.Collections;
using System;
using System.Reflection;
using System.IO;

public class TestApplicationAPI : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.TestAPI();
	}

    private string log = "!!!";

    private void TestAPI()
    {
        /*
         * PC:
        Application.loadedLevel = 0
        Application.loadedLevelName = TestApplicationAPI
        Application.isLoadingLevel = False
        Application.levelCount = 3
        Application.streamedBytes = 0
        Application.isPlaying = True
        Application.isEditor = True
        Application.isWebPlayer = False
        Application.platform = WindowsEditor
        Application.isMobilePlatform = False
        Application.isConsolePlatform = False
        Application.runInBackground = True
        Application.isPlayer = False
        Application.dataPath = D:/Jaden/Sailing/Jaden/Unity3dTests/Assets
        Application.streamingAssetsPath = D:/Jaden/Sailing/Jaden/Unity3dTests/Assets/StreamingAssets
        Application.persistentDataPath = C:/Users/xxx/AppData/LocalLow/DefaultCompany/Unity3dTests
        Application.temporaryCachePath = C:/Users/xxx/AppData/Local/Temp/DefaultCompany/Unity3dTests
        Application.srcValue = 
        Application.absoluteURL = 
        Application.absoluteUrl = 
        Application.unityVersion = 4.7.2f1
        Application.webSecurityEnabled = False
        Application.webSecurityHostUrl = http://www.mydomain.com/mygame.unity3d
        Application.targetFrameRate = -1
        Application.systemLanguage = Chinese
        Application.backgroundLoadingPriority = Normal
        Application.internetReachability = ReachableViaLocalAreaNetwork
        Application.genuine = True
        Application.genuineCheckAvailable = True
         * */

        /*
         * Android:
        Application.loadedLevel = 0
        Application.loadedLevelName = TestApplication
        Application.isLoadingLevel = False
        Application.levelCount = 1
        Application.streamedBytes = 0
        Application.isPlaying = True
        Application.isEditor = False
        Application.isWebPlayer = False
        Application.platform = Android
        Application.isMobilePlatform = True
        Application.isConsolePlatform = False
        Application.runInBackground = True
        Application.isPlayer = True
        Application.dataPath = /mnt/asec/com.sailing.jaden-2/pkg.apk
        Application.streamingAssetsPath = jar:file:///mnt/asec/com.sailing.jaden-2/pkg.apk!/assets
        Application.persistentDataPath = /storage/emulated/0/Android/data/com.sailing.jaden/files
        Application.temporaryCachePath = /storage/emulated/0/Android/data/com.sailing.jaden/cache
        Application.srcValue = 
        Application.absoluteURL = 
        Application.absoluteUrl = 
        Application.unityVersion = 4.7.2f1
        Application.webSecurityEnabled = False
        Application.webSecurityHostUrl = 
        Application.targetFrameRate = -1
        Application.systemLanguage = Chinese
        Application.backgroundLoadingPriority = Normal
        Application.internetReachability = NotReachable
        Application.genuine = True
        Application.genuineCheckAvailable = False
         * */

        //静态属性值
        System.Type type = typeof(Application);
        PropertyInfo[] infos = type.GetProperties();
        for (int i = 0; i < infos.Length; i++)
        {
            MemberInfo info = infos[i];
            log += ("Application." + infos[i].Name + " = " + infos[i].GetValue(null, null)) + "\n";
        }

        Debug.Log(log);

        //写文件
        FileStream fs = new FileStream(Application.persistentDataPath + "/" + "log.text", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        StreamWriter sw = new StreamWriter(fs);
        sw.Write(log);
        sw.Flush();
        sw.Close();
        fs.Close();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
