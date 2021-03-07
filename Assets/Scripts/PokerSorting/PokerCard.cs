using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PokerSuit
{
    梅花, 方塊, 紅心, 黑桃

}

public enum PokerRank
{
    R3, R4, R5, R6, R7, R8, R9, R10, RJ, RQ, RK, RA, R2
}

public enum SortingType
{
    從大到小, 從小到大
}

[System.Serializable]
public struct PokerCard
{
    [SerializeField] private PokerSuit suit;
    [SerializeField] private PokerRank rank;

    public PokerSuit GetSuit { get { return suit; } }
    public PokerRank GetRank { get { return rank; } }

    public PokerCard(PokerSuit _suit, PokerRank _rank)
    {
        suit = _suit;
        rank = _rank;
    }

    public string GetPokerInfo()
    {
        string _result = string.Empty;

        _result = suit.ToString() + " ";
        _result += rank.ToString().Replace("R", "");

        return _result;
    }
}
