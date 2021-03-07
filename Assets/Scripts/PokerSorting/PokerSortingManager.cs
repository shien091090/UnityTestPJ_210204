using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerSortingManager : MonoBehaviour
{
    public List<PokerCard> originDeck; //原牌組
    public List<PokerCard> displayDeck; //顯示用(已排序)牌組
    public SortingType sortingType;

    public void BTN_SortDeck()
    {
        List<PokerCard> sortedDeck = new List<PokerCard>();
        sortedDeck = SortDeck(originDeck); //排序

        if (sortedDeck == null)
        {
            Debug.Log("[ERROR]沒有牌組可供排序");
            return;
        }

        //Editor顯示
        displayDeck = sortedDeck;

        //Debug.Log
        PrintDeckInfo(displayDeck);
    }

    private List<PokerCard> SortDeck(List<PokerCard> deck)
    {
        /*
        List<int> numList = new List<int>()
        {0, 7, 6, 13, 6, 39, 2 };

        numList.Sort((int x, int y) =>
        {
            if (x > y) return 1;
            else if (x < y) return -1;
            else if (x == y) return 0;
            else return 0;
        });

        for (int i = 0; i < numList.Count; i++)
        {
            Debug.Log(string.Format("[{0}] : {1}", i, numList[i]));
        }
        */

        if (deck == null || deck.Count <= 0) return null;

        List<PokerCard> _result = new List<PokerCard>();

        _result.AddRange(deck);
        _result.Sort(PokerSorting(sortingType));

        return _result;
    }

    private void PrintDeckInfo(List<PokerCard> deck)
    {
        if (deck == null || deck.Count <= 0)
        {
            Debug.Log("[空牌組]");
            return;
        }

        for (int i = 0; i < deck.Count; i++)
        {
            Debug.Log(string.Format("[{0}] : {1}", i, deck[i].GetPokerInfo()));
        }
    }

    private System.Comparison<PokerCard> PokerSorting(SortingType type)
    {
        int resultValue = 1;

        switch (type)
        {
            case SortingType.從大到小:
                resultValue = -1;
                break;

            case SortingType.從小到大:
                resultValue = 1;
                break;
        }

        return ( (PokerCard x, PokerCard y) =>
         {
             if ((int)x.GetRank > (int)y.GetRank) return 1 * resultValue;
             else if ((int)x.GetRank < (int)y.GetRank) return -1 * resultValue;
             else if ((int)x.GetRank == (int)y.GetRank)
             {
                 if ((int)x.GetSuit > (int)y.GetSuit) return 1 * resultValue;
                 else if ((int)x.GetSuit < (int)y.GetSuit) return -1 * resultValue;
             }

             return 0;
         } );
    }
}
