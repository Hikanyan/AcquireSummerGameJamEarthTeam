using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

/// <summary> ランキングを表示するクラス </summary>
public class RankingManager : MonoBehaviour
{
    [SerializeField] private RankingData _rankingData = default;

    [SerializeField] private List<Text> _nameTexts = default;
    [SerializeField] private List<Text> _scoreTexts = default;

    public void ShowOldRanking()
    {
        var list = _rankingData.GetOldRanking();
        for (var i = 0; i < _nameTexts.Count; i++)
        {
            _nameTexts[i].text = list.rankingList[i].name;
            _scoreTexts[i].text = list.rankingList[i].score.ToString();
        }
    }

    public void ShowCurrentRanking()
    {
        var list = _rankingData.GetCurrentRanking();
        for (var i = 0; i < _nameTexts.Count; i++)
        {
            _nameTexts[i].text = list.rankingList[i].name;
            _scoreTexts[i].text = list.rankingList[i].score.ToString();
        }
    }
}