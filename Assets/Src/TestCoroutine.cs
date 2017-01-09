using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// by Jaden 2016-10-22 16:12:59
/// 协程只可以在MonoBehavior里使用
/// Start等入口可以直接定义为IEnumerator启用协程
/// 
/// </summary>
[RequireComponent(typeof(GUIText))]
public class TestCoroutine : MonoBehaviour {

	// Use this for initialization

    private int _value = 0;


	void Start () {
        GetComponent<GUIText>().text = "Click Start Button";
        Application.targetFrameRate = 25;
	}

    /*
    IEnumerator Start()
    {
        guiText.text = "Click Start Button";
        Application.targetFrameRate = 25;
        for (int i = 0; i < 100; i++)
        {
            Value++;
            yield return new WaitForSeconds(0.1f); ;
        }
    }
    */

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 200, 200, 100), "Start"))
        {
            StartCoroutine(TestCoroutine1());
        }
    }

    private int Value
    {
        get
        {
            return _value;
        }
        set
        {
            _value = value;
            GetComponent<GUIText>().text = _value.ToString();
        }
    }

    IEnumerator TestCoroutine1()
    {
        for (int i = 0; i < 20; i++)
        {
            Value++;
            yield return new WaitForSeconds(0.1f); ;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
