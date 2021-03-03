using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunction : MonoBehaviour
{
    public void BTN_FuntionA()
    {
        int v = RandomValue();
        Debug.Log("BTN_FuntionA : " + v.ToString());
    }

    public int RandomValue()
    {
        int _result = 0;

        _result = Random.Range(0, 100);

        return _result;
    }
}
