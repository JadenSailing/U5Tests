using UnityEngine;
using System.Collections;

public class TestGetComponetGC : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Transform obj = this.transform;
        Profiler.BeginSample("GetComponentGC");
        UIWidget gc = obj.GetComponent<UIWidget>();
        Profiler.EndSample();
    }
}
