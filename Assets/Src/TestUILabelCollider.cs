using UnityEngine;
using System.Collections;

public class TestUILabelCollider : MonoBehaviour {

    public UILabel label;
	// Use this for initialization
	void Start () {
        InvokeRepeating("SetText1", 1.0f, 2.0f);
        InvokeRepeating("SetText2", 2.0f, 2.0f);
    }

    void SetText1()
    {
        label.text = "";
    }

    void SetText2()
    {
        label.gameObject.SetActive(false);
        label.text = "这是一句特别长的话这是一句特别长的话这是一句特别长的话这是一句特别长的话这是一句特别长的话这是一句特别长的话这是一句特别长的话";
        label.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
