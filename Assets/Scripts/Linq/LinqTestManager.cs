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

public class SlotItem
{
    public int itemNum; //道具編號
    public CardType cardType; //卡別
    public LobbyType lobbyType; //廳別
    public int starLevel; //星等

    public SlotItem(int _itemNum, CardType _cardType, LobbyType _lobbyType, int _starLv)
    {
        itemNum = _itemNum;
        cardType = _cardType;
        lobbyType = _lobbyType;
        starLevel = _starLv;
    }

    public void DebugInfo()
    {
        Debug.Log(string.Format("[ID:{0}] [{1}] [{2}] [{3}星]", itemNum, cardType, lobbyType, starLevel));
    }
}

public class LinqTestManager : MonoBehaviour
{
    public void BTN_LinqTest()
    {
        List<SlotItem> items = new List<SlotItem>();
        for (int i = 0; i < 12; i++)
        {
            int _itemNum = UnityEngine.Random.Range(1, 50);
            CardType _cardType = (CardType)UnityEngine.Random.Range(0, 5);
            LobbyType _lobbyType = (LobbyType)UnityEngine.Random.Range(0, 4);
            int _starLv = UnityEngine.Random.Range(1, 10);
            items.Add(new SlotItem(_itemNum, _cardType, _lobbyType, _starLv));
        }

        Debug.Log("======== 初始列表 ========");

        for (int i = 0; i < items.Count; i++)
        {
            items[i].DebugInfo();
        }

        //IEnumerable<SlotItem> slotItemQuery =
        //    items.OrderBy(x => x.cardType)
        //    .ThenBy(x => x.lobbyType)
        //    .ThenByDescending(x => x.starLevel)
        //    .ThenByDescending(x => x.itemNum);

//道具先按照卡別>廳別>星數排序之後, 再篩選出廳別為"至尊廳"的道具

IEnumerable<SlotItem> slotItemQuery =
    from item in items
    .OrderBy(x => x.cardType)
    .ThenBy(x => x.lobbyType)
    .ThenByDescending(x => x.starLevel)
    where item.lobbyType == LobbyType.至尊聽
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
