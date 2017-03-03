using UnityEngine;
using System.Collections;

public class TestTypeClass1
{
    public int a = 1;
    public int b
    {
        get
        {
            return 2;
        }
    }

    public static int c
    {
        get
        {
            return 3;
        }
    }

    public static int d = 4;
    public TestTypeClass1()
    {

    }
}

public class TestType : MonoBehaviour {

	// Use this for initialization
	void Start () {

        string typeStr = "";
        typeStr = TypeUtil.GetFieldInfo(new TestTypeClass1());
        print(typeStr);

        typeStr = TypeUtil.GetPropertyInfo(new TestTypeClass1());
        print(typeStr);

        typeStr = TypeUtil.GetMemberInfo(new TestTypeClass1());
        print(typeStr);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
}
