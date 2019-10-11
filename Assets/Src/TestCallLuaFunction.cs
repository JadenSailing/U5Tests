using UnityEngine;
using System.Collections;
using LuaInterface;

public class TestCallLuaFunction : MonoBehaviour {
    private string script =
        @"  function luaFunc(num)                        
                return num + 1
            end
            
            function luaFuncStr(str)                        
                return str .. str;
            end

            test = {}
            test.luaFunc = luaFunc
            test.luaFuncStr = luaFuncStr
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
            UnityEngine.Profiling.Profiler.BeginSample("有GC");
            object[] r = func.Call(123456);
            UnityEngine.Profiling.Profiler.EndSample();
            Debugger.Log("generic call return: {0}", r[0]);

            // no gc alloc
            UnityEngine.Profiling.Profiler.BeginSample("无GC");
            int num = CallFunc(func);
            UnityEngine.Profiling.Profiler.EndSample();
            Debugger.Log("expansion call return: {0}", num);

            //有gc alloc
            func = _state.GetFunction("test.luaFuncStr");
            UnityEngine.Profiling.Profiler.BeginSample("有GCStr");
            object[] r2 = func.Call("AAA");
            UnityEngine.Profiling.Profiler.EndSample();
            Debugger.Log("generic call return: {0}", r2[0]);

            // no gc alloc
            UnityEngine.Profiling.Profiler.BeginSample("无GCStr");
            string str = CallFunc2(func);
            UnityEngine.Profiling.Profiler.EndSample();
            Debugger.Log("expansion call return: {0}", str);
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

    string CallFunc2(LuaFunction func)
    {
        func.BeginPCall();
        func.Push("AAA");
        func.PCall();
        string num = (string)func.CheckString();
        func.EndPCall();
        return num;
    }
}
