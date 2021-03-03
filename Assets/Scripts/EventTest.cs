using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventTest : MonoBehaviour
{
    public System.Action<int> systemAct;
    public System.Func<int, int> systemFun;
    public System.EventHandler systemHandler;
    public UnityEngine.Events.UnityAction<int> unityAct;
    public UnityEngine.Events.UnityEvent unityEvt;

    public KeyCode[] testKey;

    //------------------------------------------------------------------------------------------------------------------------

    void Start()
    {
        systemAct += MethodWithInputA;
        systemAct += MethodWithInputB;

        systemFun += MethodWithInOutA;
        systemFun += MethodWithInOutB;

        systemHandler += MethodWithHandlerA;
        systemHandler += MethodWithHandlerB;

        unityAct += MethodWithInputA;
        unityAct += MethodWithInputB;

        unityEvt.AddListener(MethodA);
        unityEvt.AddListener(MethodB);
    }

    void Update()
    {
        for (int i = 0; i < testKey.Length; i++)
        {
            if (Input.GetKeyDown(testKey[i])) SendMessage("KeyMethod" + i);
        }
    }

    //------------------------------------------------------------------------------------------------------------------------

    public void KeyMethod0()
    {
        systemAct.Invoke(10);
    }

    public void KeyMethod1()
    {
        int _i = 10;
        Debug.Log("total = " + systemFun(_i));
    }

    public void KeyMethod2()
    {
        systemHandler.Invoke(this, System.EventArgs.Empty);
    }

    public void KeyMethod3()
    {
        unityAct.Invoke(5);
    }

    public void KeyMethod4()
    {
        unityEvt.Invoke();
    }

    public void KeyMethod5()
    {
        SceneManager.LoadScene("MainScene");
    }

    //------------------------------------------------------------------------------------------------------------------------

    public void MethodA()
    {
        Debug.Log("MethodA");
    }

    private void MethodB()
    {
        Debug.Log("MethodB");
    }

    public int MethodWithOutputA()
    {
        Debug.Log("MethodWithParamA");
        return 0;
    }

    private int MethodWithOutputB()
    {
        Debug.Log("MethodWithParamB");
        return 0;
    }

    public void MethodWithInputA(int v)
    {
        Debug.Log("MethodWithInputA : " + v);
    }

    private void MethodWithInputB(int v)
    {
        Debug.Log("MethodWithinputB : " + v);
    }

    public int MethodWithInOutA(int v)
    {
        Debug.Log("MethodWithInOutA : " + v + " ×2 = " + ( v * 2 ));
        v *= 2;
        return v;
    }

    private int MethodWithInOutB(int v)
    {
        Debug.Log("MethodWithInOutB : " + v + " ×5 = " + ( v * 5 ));
        v *= 5;
        return v;
    }

    public void MethodWithHandlerA(object sender, System.EventArgs e)
    {
        Debug.Log("MethodWithHandlerA");
    }

    private void MethodWithHandlerB(object sender, System.EventArgs e)
    {
        Debug.Log("MethodWithHandlerB");
    }


}
