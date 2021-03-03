using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public struct SNStruct
{
    public string name;
    public int number;

    public SNStruct(string _name, int _num)
    {
        name = _name;
        number = _num;
    }
}

[System.Serializable]
public class SNClass
{
    public string name;
    public int number;

    public SNClass(string _name, int _num)
    {
        name = _name;
        number = _num;
    }
}

[System.Serializable]
public class MyEvent : UnityEngine.Events.UnityEvent<SNClass>
{

}