using System;
using System.Collections.Generic;
using System.IO;
using GameJamProject.System;
using UnityEngine;

[Serializable]
public class RankingList
{
    public List<SaveDataItem> rankingList = new List<SaveDataItem>();
}

[Serializable]
public class SaveDataItem
{
    public string name;
    public int score;
}


/// <summary> jsonから読み込んでランキングを書き換えてjsonにデータの保存をするクラス </summary>
public class SaveManager : Singleton<SaveManager>
{
    [SerializeField] private RankingData _rankingData = default;
    [SerializeField] private string _name = default;
    [SerializeField] private int _score = default;
    protected override bool UseDontDestroyOnLoad => true;
    private const string _filePath = "Assets/Resources/Scores.json";
    private const string _fileName = "Scores";
    
    public void GetScore(int score)
    {
        _score = score;
    }
    
    public void Save()
    {
        // jsonデータの読み込み
        string jsonData = Resources.Load<TextAsset>(_fileName).ToString();

        // 読み込んだデータをlistに格納
        RankingList itemList = JsonUtility.FromJson<RankingList>(jsonData);

        // 古いランキングデータを保存
        var oldRanking = new RankingList();
        oldRanking.rankingList = new List<SaveDataItem>(itemList.rankingList);
        _rankingData.SaveOldRanking(oldRanking);

        // 新しいデータをランキングに追加
        SaveDataItem saveDataItem = new SaveDataItem();
        saveDataItem.name = _name;
        saveDataItem.score = _score;

        itemList.rankingList.Add(saveDataItem);
        RankingList currentRanking = Rank(itemList);

        // 新しいランキングデータを保存
        _rankingData.SaveCurrentRanking(currentRanking);

        // リストをjsonに保存
        string jsonStr = JsonUtility.ToJson(itemList);

        StreamWriter writer = new StreamWriter(_filePath, false);

        writer.Write(jsonStr);

        writer.Flush();
        writer.Close();
    }

    /// <summary> ランキングを降順に並べ替え </summary>
    /// <param name="list">新しいデータが入ってまだ降順になっていないランキング</param>
    /// <returns> 降順になったランキング</returns>
    private RankingList Rank(RankingList list)
    {
        list.rankingList.Sort((a, b) => b.score - a.score);
        return list;
    }
}