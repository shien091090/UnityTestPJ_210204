using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class TypeMethodTest : MonoBehaviour
{
    public void BTN_Test()
    {
        Type _t = typeof(TypeMethodClass);
        MethodInfo _m = _t.GetMethod("ShowDebugLog");

        _m.Invoke(null,null);
    }


}

public class TypeMethodClass
{
    public static void ShowDebugLog()
    {
        Debug.Log("Test : ShowDebugLog");
    }
}