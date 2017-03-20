using UnityEngine;
using System.Collections;
using LuaInterface;

public class TestCallLuaFunction : MonoBehaviour {
    private string script =
        @"  function luaFunc(num)                        
                return num + 1
            end

            test = {}
            test.luaFunc = luaFunc
        ";
    LuaState _state;
	// Use this for initialization
	void Start () {
        _state = new LuaState();
        _state.Start();
        LuaBinder.Bind(_state);
        _state.DoString(script);
    }
	
	// Update is called once per frame
	void Update () {
        LuaFunction func = _state.GetFunction("test.luaFunc");

        if (func != null)
        {
            //有gc alloc
            UnityEngine.Profiler.BeginSample("有GC");
            object[] r = func.Call(123456);
            UnityEngine.Profiler.EndSample();
            Debugger.Log("generic call return: {0}", r[0]);

            // no gc alloc
            UnityEngine.Profiler.BeginSample("无GC");
            int num = CallFunc(func);
            UnityEngine.Profiler.EndSample();
            Debugger.Log("expansion call return: {0}", num);
        }
    }

    int CallFunc(LuaFunction func)
    {
        func.BeginPCall();
        func.Push(123456);
        func.PCall();
        int num = (int)func.CheckNumber();
        func.EndPCall();
        return num;
    }
}
