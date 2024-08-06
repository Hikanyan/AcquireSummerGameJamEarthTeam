using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Text _text = default;
    public void ChangeScore(int score)
    {
        _text.text = score.ToString();
    }
}
