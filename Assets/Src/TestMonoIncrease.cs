using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestMonoIncrease : MonoBehaviour {

    public GameObject item;

    public List<GameObject> itemList;
    // Use this for initialization
    void Start() {
        itemList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update() {
        System.GC.Collect();
    }

    void OnGUI()
    {
        if(GUI.Button(new Rect(0, 0, 200, 100), "Add"))
        {
            for (int i = 0; i < 1000; i++)
            {
                itemList.Add(GameObject.Instantiate(item));
            }
        }

        if (GUI.Button(new Rect(0, 100, 200, 100), "Remove"))
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                GameObject.Destroy(itemList[i]);
            }
            itemList.Clear();

            
        }
    }
}
