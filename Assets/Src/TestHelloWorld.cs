using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;

public class TestHelloWorld : MonoBehaviour {

    private string SrcPath = "/Scenes";
	// Use this for initialization
	void Start () {
        Debug.Log("Hello World");

        SrcPath = Application.dataPath + SrcPath;
        string allFiles = "";
        if(Directory.Exists(SrcPath))
        {
            string[] files = Directory.GetFiles(SrcPath, "*.unity", SearchOption.TopDirectoryOnly);
            Array.Sort(files);
            for (int i = 0; i < files.Length; i++)
            {
                string fileName = files[i];
                int lastIndex = fileName.LastIndexOf("\\");
                fileName = fileName.Substring(lastIndex + 1, fileName.Length - lastIndex - 7);
                string index = (i+1) < 10 ? "0" + (i + 1).ToString() : (i + 1).ToString();
                allFiles = allFiles + index + "." + fileName + "\n\r";
            }
        }
        Debug.Log(allFiles);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
