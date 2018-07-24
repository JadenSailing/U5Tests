using UnityEngine;
using System.Collections;

public class TestRotationPos : MonoBehaviour {
    public GameObject objParent;
    public GameObject objChild;
	// Use this for initialization
	void Start () {
        Application.targetFrameRate = 5;
	}
	
	// Update is called once per frame
	void Update () {
        string log = "<color=#00FF00>position = " + objChild.transform.position + "</color>";
        UnityEngine.Debug.Log(log);

        Vector3 pos = objParent.transform.rotation * objChild.transform.localPosition;
        log = "<color=#00FF00>rotationPos = " + pos + "</color>";
        UnityEngine.Debug.Log(log);
        
    }
}
