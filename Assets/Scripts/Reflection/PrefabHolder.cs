using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class PrefabHolder : MonoBehaviour
{
    public const string PREFAB_NAME_PREFIX = "Prefab";

    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;
    public GameObject prefab6;
    public GameObject prefab7;

    private Dictionary<string, GameObject> goTable;

    private void Awake()
    {
        Init();
    }

    public GameObject GetGo(int num)
    {
        GameObject _result = null;

        goTable.TryGetValue(PREFAB_NAME_PREFIX + num.ToString(), out _result);

        return _result;
    }

    private void Init()
    {
        CheckReferences();
        BuildPrefabDictionary();
    }

    private void BuildPrefabDictionary()
    {
        goTable = new Dictionary<string, GameObject>();

        FieldInfo[] fieldArr = typeof(PrefabHolder).GetFields();
        int _index = 0;
        for (int i = 0; i < fieldArr.Length; i++)
        {
            if (fieldArr[i].FieldType != typeof(GameObject)) continue;

            goTable.Add(PREFAB_NAME_PREFIX + _index.ToString(), (GameObject)fieldArr[i].GetValue(this));
            _index++;
        }
    }

    private void ReplaceGameObject(FieldInfo field, GameObject prefab)
    {
        if (prefab.activeInHierarchy) return;

        GameObject _hierarchyGo = Instantiate(prefab, this.transform);
        field.SetValue(this, _hierarchyGo);
    }

    private void CheckReferences()
    {
        FieldInfo[] fieldsArr = typeof(PrefabHolder).GetFields();

        for (int i = 0; i < fieldsArr.Length; i++)
        {
            if (fieldsArr[i].FieldType == typeof(GameObject))
            {
                GameObject _go = (GameObject)fieldsArr[i].GetValue(this);
                if (_go == null) _go = GetPrefabResource(PREFAB_NAME_PREFIX + i.ToString());

                if (_go != null)
                {
                    fieldsArr[i].SetValue(this, _go);
                    ReplaceGameObject(fieldsArr[i], _go);
                }

            }
        }

        //Debug.Log(string.Format("[{0}] Name = {1}", i, fieldArr[i].Name));
        //Debug.Log(string.Format("[{0}] FieldType = {1}", i, fieldArr[i].FieldType));
        //Debug.Log(string.Format("[{0}] DeclaringType = {1}", i, fieldArr[i].DeclaringType));
        //Debug.Log(string.Format("[{0}] IsAssembly = {1}", i, fieldArr[i].IsAssembly));
        //Debug.Log(string.Format("[{0}] IsFamily = {1}", i, fieldArr[i].IsFamily));
        //Debug.Log(string.Format("[{0}] IsFamilyAndAssembly = {1}", i, fieldArr[i].IsFamilyAndAssembly));
        //Debug.Log(string.Format("[{0}] IsFamilyOrAssembly = {1}", i, fieldArr[i].IsFamilyOrAssembly));
        //Debug.Log(string.Format("[{0}] IsInitOnly = {1}", i, fieldArr[i].IsInitOnly));
        //Debug.Log(string.Format("[{0}] IsLiteral = {1}", i, fieldArr[i].IsLiteral));
        //Debug.Log(string.Format("[{0}] IsNotSerialized = {1}", i, fieldArr[i].IsNotSerialized));
        //Debug.Log(string.Format("[{0}] IsPinvokeImpl = {1}", i, fieldArr[i].IsPinvokeImpl));
        //Debug.Log(string.Format("[{0}] IsPrivate = {1}", i, fieldArr[i].IsPrivate));
        //Debug.Log(string.Format("[{0}] IsPublic = {1}", i, fieldArr[i].IsPublic));
        //Debug.Log(string.Format("[{0}] IsSecurityCritical = {1}", i, fieldArr[i].IsSecurityCritical));
        //Debug.Log(string.Format("[{0}] IsSecuritySafeCritical = {1}", i, fieldArr[i].IsSecuritySafeCritical));
        //Debug.Log(string.Format("[{0}] IsSecurityTransparent = {1}", i, fieldArr[i].IsSecurityTransparent));
        //Debug.Log(string.Format("[{0}] IsSpecialName = {1}", i, fieldArr[i].IsSpecialName));
        //Debug.Log(string.Format("[{0}] IsStatic = {1}", i, fieldArr[i].IsStatic));
        //Debug.Log(string.Format("[{0}] MemberType = {1}", i, fieldArr[i].MemberType));
        //Debug.Log(string.Format("[{0}] MetadataToken = {1}", i, fieldArr[i].MetadataToken));
        //Debug.Log(string.Format("[{0}] ReflectedType = {1}", i, fieldArr[i].ReflectedType));
    }

    private GameObject GetPrefabResource(string name)
    {
        GameObject _result = null;

        _result = Resources.Load<GameObject>(name);

        return _result;
    }
}
