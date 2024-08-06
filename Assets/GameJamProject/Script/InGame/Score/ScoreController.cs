using UnityEngine;
using UniRx;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private ScoreLogic _model = default;
    [SerializeField] private ScoreView _view = default;
    private void Start()
    {
        _model.Score.Subscribe(score => _view.ChangeScore(score)).AddTo(this);
    }

    public void AddScore(int num)
    {
        _model.AddScore(num);
    }
}
