using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class ReflectionTestManager : MonoBehaviour
{
    public int selectedNumber;

    public PrefabHolder prefabHolder;


    public void BTN_ReflectionTest()
    {
        GameObject _target = prefabHolder.GetGo(selectedNumber);

        if (_target != null) _target.SetActive(!_target.activeSelf);
    }



}
