using System;
using UnityEngine;
using UniRx;

public class ScoreLogic : MonoBehaviour
{
    private IntReactiveProperty _score = new IntReactiveProperty(0);
    public IReadOnlyReactiveProperty<int> Score => _score;

    private void Start()
    {
        _score = new IntReactiveProperty(0);
    }

    public void AddScore(int score)
    {
        _score.Value += score;
    }
}
