using UnityEngine;
using System.Collections;
using UnityEditor;

public class TestAssetBundleEditor : Editor {

    private static BuildAssetBundleOptions buildOp = BuildAssetBundleOptions.ChunkBasedCompression | BuildAssetBundleOptions.DeterministicAssetBundle/* | BuildAssetBundleOptions.AppendHashToAssetBundleName*/;// | BuildAssetBundleOptions.CompleteAssets;

    [MenuItem("Tools/BuildScene", false, 12)]
    public static void BuildScene()
    {
        string[] sceneNameList;
        /*
        EditorBuildSettingsScene[] t_Scene = EditorBuildSettings.scenes;
        sceneNameList = new string[t_Scene.Length];
        for (int i = 0; i < t_Scene.Length; i++)
        {
            sceneNameList[i] = t_Scene[i].path;
        }
        */
        sceneNameList = new string[1];
        sceneNameList[0] = "Assets/Scenes/TestAssetBundleScene1.unity";
        BuildPipeline.BuildPlayer(sceneNameList, Application.streamingAssetsPath + "/Scenes/" + "Test.Scene", BuildTarget.Android, BuildOptions.BuildAdditionalStreamedScenes);

        AssetDatabase.Refresh();
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Tools/BuildFont", false, 12)]
    public static void BuildFont()
    {
        AssetBundleBuild[] abs = new AssetBundleBuild[1];
        AssetBundleBuild ab = new AssetBundleBuild();
        ab.assetBundleName = "FZ" + ".ab";
        string[] AssetNames = new[] { "Assets/Resources/Fonts/FZLTH-GBK.TTF", "Assets/Resources/Fonts/lthj.otf" };
        ab.assetNames = AssetNames;

        abs[0] = ab;
        BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath + "/Fonts/", abs, buildOp, BuildTarget.Android);
    }

    /// <summary>
    /// 已知依赖
    /// </summary>
    [MenuItem("Tools/TestBuild1", false, 12)]
    public static void TestBuild1()
    {
        int max = 5;
        int index = 0;
        AssetBundleBuild[] abs = new AssetBundleBuild[max];
        AssetBundleBuild ab;
        string[] AssetNames;

        //Texture
        ab = new AssetBundleBuild();
        ab.assetBundleName = "icon" + ".ab";
        AssetNames = new[] { "Assets/Resources/UI/Image/Skill/tianshan02.png" };
        ab.assetNames = AssetNames;
        abs[index++] = ab;

        //Build Font
        ab = new AssetBundleBuild();
        ab.assetBundleName = "font" + ".ab";
        AssetNames = new[] { "Assets/Resources/TestAB/Fonts/FZLTH-GBK.TTF"};
        ab.assetNames = AssetNames;
        abs[index++] = ab;

        //Build Prefab
        for (int i = 0; i < 3; i++)
        {
            ab = new AssetBundleBuild();
            ab.assetBundleName = "TestABPanel" + (i+1).ToString() + ".ab";
            AssetNames = new[] { "Assets/Resources/TestAB/UI/Prefab/TestABPanel" + (i + 1).ToString() + ".prefab" };
            ab.assetNames = AssetNames;
            abs[index++] = ab;
        }
        BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath + "/TestAB", abs, buildOp, BuildTarget.Android);
    }
}
