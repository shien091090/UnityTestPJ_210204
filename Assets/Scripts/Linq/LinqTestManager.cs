using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public enum CardType
{
    黑卡, 紫卡, 紅卡, 黃卡, 藍卡
}

public enum LobbyType
{
    至尊聽, 高手廳, 一般廳, 體驗廳
}

public class NewCardInfo
{
    public int gotTime;

    public NewCardInfo()
    {
        gotTime = UnityEngine.Random.Range(1, 50);
    }
}

public class SlotItem
{
    public NewCardInfo newCardInfo; //新卡片資訊
    public int itemNum; //道具編號
    public CardType cardType; //卡別
    public LobbyType lobbyType; //廳別
    public int starLevel; //星等

    public SlotItem(NewCardInfo _newCardInfo, int _itemNum, CardType _cardType, LobbyType _lobbyType, int _starLv)
    {
        newCardInfo = _newCardInfo;
        itemNum = _itemNum;
        cardType = _cardType;
        lobbyType = _lobbyType;
        starLevel = _starLv;
    }

    public void DebugInfo()
    {
        Debug.Log(string.Format("[ID:{0}] <{1} : {2}> [{3}] [{4}] [{5}星]",
            itemNum,
            ( newCardInfo == null ? "OLD" : "NEW" ),
            ( newCardInfo == null ? "-" : newCardInfo.gotTime.ToString() ),
            cardType,
            lobbyType,
            starLevel));
    }
}

public class LinqTestManager : MonoBehaviour
{
    public void BTN_LinqTest()
    {
        List<SlotItem> items = new List<SlotItem>();
        for (int i = 0; i < 20; i++)
        {
            int _oldNew = UnityEngine.Random.Range(0, 2);
            NewCardInfo _newCardInfo = _oldNew == 0 ? null : new NewCardInfo();
            int _itemNum = UnityEngine.Random.Range(1, 50);
            CardType _cardType = (CardType)UnityEngine.Random.Range(0, 5);
            LobbyType _lobbyType = (LobbyType)UnityEngine.Random.Range(0, 4);
            int _starLv = UnityEngine.Random.Range(1, 10);

            items.Add(new SlotItem(_newCardInfo, _itemNum, _cardType, _lobbyType, _starLv));
        }

        Debug.Log("======== 初始列表 ========");

        for (int i = 0; i < items.Count; i++)
        {
            items[i].DebugInfo();
        }

        IEnumerable<SlotItem> slotItemQuery =
            from item in items
            .OrderByDescending((SlotItem item) =>
            {
                if (item.newCardInfo != null) return item.newCardInfo.gotTime;
                else return -1;
            })
            .ThenBy(x => x.cardType)
            .ThenBy(x => x.lobbyType)
            .ThenByDescending(x => x.starLevel)
                //where item.lobbyType == LobbyType.至尊聽
            select item;


        List<SlotItem> sortedItems = new List<SlotItem>();
        sortedItems.AddRange(slotItemQuery.ToList());

        Debug.Log("======== 排序後 ========");

        for (int i = 0; i < sortedItems.Count; i++)
        {
            sortedItems[i].DebugInfo();
        }

    }
}
