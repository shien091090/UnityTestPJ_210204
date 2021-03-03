using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using UnityEngine.UI;

public class CultureTest : MonoBehaviour
{
    public Text textPanel;
    private string displayContent;

    public CultureInfo info;
    public CultureTypes type;

    public void BTN_CultureTest()
    {
        info = CultureInfo.CurrentCulture;

        ClearText();

        AddText("[CurrentCulture] DisplayName : " + info.DisplayName);
        AddText("[CurrentCulture] Name : " + info.Name);
        AddText("[CurrentCulture] EnglishName : " + info.EnglishName);
        AddText("[CurrentCulture] NativeName : " + info.NativeName);
        AddText("[CurrentCulture] TwoLetterISOLanguageName : " + info.TwoLetterISOLanguageName);
        AddText("[CurrentCulture] ThreeLetterISOLanguageName : " + info.ThreeLetterISOLanguageName);
        AddText("[CurrentCulture] ThreeLetterWindowsLanguageName : " + info.ThreeLetterWindowsLanguageName);
        AddText("[CurrentCulture] DateTimeFormat.ShortDatePattern : " + info.DateTimeFormat.ShortDatePattern);
        AddText("[CurrentCulture] DateTimeFormat.ShortTimePattern : " + info.DateTimeFormat.ShortTimePattern);
        AddText("[CurrentCulture] DateTimeFormat.LongDatePattern : " + info.DateTimeFormat.LongDatePattern);
        AddText("[CurrentCulture] DateTimeFormat.LongTimePattern : " + info.DateTimeFormat.LongTimePattern);
        AddText("[CurrentCulture] DateTimeFormat.DayNames[0] : " + info.DateTimeFormat.DayNames[0]);
        AddText("[CurrentCulture] LCID : " + info.LCID);
        AddText("[CurrentCulture] NumberFormat : " + info.NumberFormat);
        AddText("[CurrentCulture] Calendar : " + info.Calendar);
        AddText("[CurrentCulture] OptionalCalendars : " + info.OptionalCalendars);
        AddText("[CurrentCulture] TextInfo : " + info.TextInfo);
        AddText("[CurrentCulture] UseUserOverride : " + info.UseUserOverride);

        textPanel.text = displayContent;
    }

    public void BTN_GetCultures()
    {
        ClearText();

        CultureInfo[] cultureGroup = CultureInfo.GetCultures(type);

        for (int i = 0; i < cultureGroup.Length; i++)
        {
            AddText(string.Format("[{0}] : {1}", ( i + 1 ), cultureGroup[i].Name));
        }

        textPanel.text = displayContent;
    }

    public void AddText(string t)
    {
        displayContent += t + "\n";
    }

    public void ClearText()
    {
        displayContent = string.Empty;
    }
}
