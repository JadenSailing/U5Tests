using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TestSpringBoneManager : MonoBehaviour {
    public List<TestSpringBone> SpringBoneList;

	// Use this for initialization
	void Start () {
        for (int i = SpringBoneList.Count - 1; i >= 0; i--)
        {
            SpringBoneList[i].StartSpring();
        }
    }
    
	
	// Update is called once per frame
	void LateUpdate() {
        for (int i = 0; i < SpringBoneList.Count; i++)
        {
            SpringBoneList[i].UpdateSpring();
        }

    }
}
