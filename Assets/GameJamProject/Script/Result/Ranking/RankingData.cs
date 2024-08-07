using System;
using UnityEngine;

/// <summary> ランキングの古いデータと新しいデータを保存するクラス </summary>
public class RankingData : MonoBehaviour
{
    private RankingList _currentRankData = default;
    private RankingList _oldRankData = default;
    
    
    private void Start()
    {
        _currentRankData = new RankingList();
        _oldRankData = new RankingList();
    }

    public void SaveOldRanking(RankingList list)
    {
        _oldRankData = list;
    }

    public void SaveCurrentRanking(RankingList list)
    {
        _currentRankData = list;
    }

    public RankingList GetOldRanking()
    {
        return _oldRankData;
    }
    
    public RankingList GetCurrentRanking()
    {
        return _currentRankData;
    }
}
