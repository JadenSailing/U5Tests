using UnityEngine;
using System.Collections;
using UnityEditor;

//下面这个标签只是意味着在编辑器模式下也会执行MonoBehaviour行为
//主要是Update和LateUpdate 但并非逐帧执行 而是在有变化时。 NGUIPanel的编辑器制作有应用
[ExecuteInEditMode]
public class TestMonoBehaviour : MonoBehaviour {

    public GameObject Script1;
    public GameObject Script2;

	// Use this for initialization
	void Start () {
        Debug.Log("Main Start" + Time.frameCount);

        //编辑器下修改执行顺序
        MonoImporter.SetExecutionOrder(MonoScript.FromMonoBehaviour(this), 1);
	}
	
	/// <summary>
    /// 每帧调用 Update->LateUpdate 不同组件的Update的执行顺序不定 除非指定meta文件里的"executionOrder"
	/// </summary>
	void Update () {
        if(Time.frameCount < 10)
        {
            Debug.Log("Main Update" + Time.frameCount);
        }

        //这个节点的调试结果
        /* Main Update4
         * Main LateUpdate4
         * 
         * Main Update5
         * Begin Set Active true...
         * 
         * TestMonoAwake1-5
         * TestMonoEnable1-5
         * Obj1 Set Active true
         * 
         * TestMonoAwake2-5
         * TestMonoEnable2-5
         * Obj2 Set Active true
         * 
         * TestMonoStart1-5
         * TestMonoStart2-5
         * 
         * Main LateUpdate5
         * TestMonoLateUpdate1-5
         * TestMonoLateUpdate2-5
         * 
         * Main Update6
         * TestMonoUpdate1-6
         * TestMonoUpdate2-6
         * 
         * */
        if (Time.frameCount == 5)
        {
            Debug.Log("Begin Set Active true...");
            Script1.SetActive(true);
            Debug.Log("Obj1 Set Active true");
            Script1.SetActive(true); //反复调用不会重复触发
            Debug.Log("Obj1 Set Active true");
            Script1.SetActive(true);
            Debug.Log("Obj1 Set Active true");
            Script2.SetActive(true);
            Debug.Log("Obj2 Set Active true");
        }
	}

    void LateUpdate()
    {
        if (Time.frameCount < 10)
        {
            Debug.Log("Main LateUpdate" + Time.frameCount);
        }
    }
}
