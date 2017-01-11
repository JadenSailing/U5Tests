using UnityEngine;
using System.Collections;

/// <summary>
/// 镜头光晕
/// </summary>
public class TestLensFlare : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject obj = Resources.Load("Other/LensFlare/LensFlare") as GameObject;
        GameObject inst = GameObject.Instantiate(obj);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
