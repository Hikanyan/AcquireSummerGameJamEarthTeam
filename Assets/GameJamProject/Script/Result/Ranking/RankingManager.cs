using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

/// <summary> ランキングを表示するクラス </summary>
public class RankingManager : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> _nameTexts = default;
    [SerializeField] private List<TMP_Text> _scoreTexts = default;

    private async void Start()
    {
        await Animation();
    }
    
    public void ShowOldRanking()
    {
        var list = RankingData.Instance.GetOldRanking();
        for (var i = 0; i < _nameTexts.Count; i++)
        {
            _nameTexts[i].text = list.rankingList[i].name;
            _scoreTexts[i].text = list.rankingList[i].score.ToString();
        }
    }

    public void ShowCurrentRanking()
    {
        var list = RankingData.Instance.GetCurrentRanking();
        for (var i = 0; i < _nameTexts.Count; i++)
        {
            _nameTexts[i].text = list.rankingList[i].name;
            _scoreTexts[i].text = list.rankingList[i].score.ToString();
        }
    }

    private async UniTask Animation()
    {
        ShowOldRanking();
        await UniTask.Delay(1000);
        ShowCurrentRanking();
    }
}