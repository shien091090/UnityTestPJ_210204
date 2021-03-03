using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class RegexTest : MonoBehaviour
{
    [Multiline(10)]
    public string originContent;
    public string regexPattern;
    public RegexOptions options;

    /// <summary>
    /// (按鈕事件)Regex Test
    /// </summary>
    public void BTN_RegexTest()
    {
        if (regexPattern == string.Empty || originContent == string.Empty) return;

        List<string> _strList = FilterContent(originContent, regexPattern, options);
        ShowMessage(_strList);
    }

    /// <summary>
    /// Debug.Log顯示
    /// </summary>
    private void ShowMessage(List<string> c)
    {
        if (c == null || c.Count <= 0) return;

        for (int i = 0; i < c.Count; i++)
        {
            Debug.Log(string.Format("[{0}] = {1}", i, c[i]));
        }
    }

    /// <summary>
    /// 過濾文章轉換成String Array
    /// </summary>
    private List<string> FilterContent(string _input, string _pattern, RegexOptions _options)
    {
        List<string> _result = new List<string>();

        //Regex過濾
        Regex _reg = new Regex(_pattern, _options);
        MatchCollection _col = _reg.Matches(_input);

        foreach (Match _m in _col)
        {
            _result.Add(_m.Value);
        }

        return _result;
    }
}