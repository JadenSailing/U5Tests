#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;

//Allow an editor class to be initialized when Unity loads without action from the user.
//require static constructor
//[InitializeOnLoad]
public class TestEditorHandle : Editor {

    static TestEditorHandle()
    {
        SceneView.onSceneGUIDelegate -= OnSceneGUI;
        SceneView.onSceneGUIDelegate += OnSceneGUI;
    }
    private static void DrawLines()
    {
        Handles.color = Color.green;
        Vector3 centerPt = new Vector3(0, 0, 0);
        Handles.DrawLine(Vector3.zero + centerPt, Vector3.right + centerPt);
        Handles.DrawLine(Vector3.zero + centerPt, Vector3.left + centerPt);
        Handles.DrawLine(Vector3.zero + centerPt, Vector3.up + centerPt);
        Handles.DrawLine(Vector3.zero + centerPt, Vector3.down + centerPt);
        Handles.DrawLine(Vector3.zero + centerPt, Vector3.forward + centerPt);
        Handles.DrawLine(Vector3.zero + centerPt, Vector3.back + centerPt);
    }

    static void OnSceneGUI(SceneView sceneView)
    {
        DrawLines();
    }
}
#endif