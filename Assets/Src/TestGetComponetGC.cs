using UnityEngine;
using System.Collections;

public class TestGetComponetGC : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Transform obj = this.transform;
        UnityEngine.Profiling.Profiler.BeginSample("GetComponentGC");
        UIWidget gc = obj.GetComponent<UIWidget>();
        UnityEngine.Profiling.Profiler.EndSample();
    }
}
