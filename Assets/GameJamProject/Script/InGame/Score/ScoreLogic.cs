using UnityEngine;
using UniRx;

public class ScoreLogic : MonoBehaviour
{
    private IntReactiveProperty _score = default;
    public IReadOnlyReactiveProperty<int> Score => _score;

    public void AddScore(int score)
    {
        _score.Value += score;
        Debug.Log("Score : " + _score.Value);
    }
}