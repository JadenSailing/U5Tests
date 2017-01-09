using UnityEngine;
using System.Collections;

public class TestProjector : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Application.targetFrameRate = 30;
	}
	
	// Update is called once per frame
	void Update () {
        float y = this.transform.eulerAngles.y;
        y = y + 1.0f;
        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, y, this.transform.eulerAngles.z);
	}
}
