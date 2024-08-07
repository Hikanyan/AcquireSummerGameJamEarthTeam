using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : PlayerParameter
{
    [SerializeField] private List<Sprite> _hpImageList = default;
    [SerializeField] private Image _image = default;
    
    void Start()
    {
        //現在のHPを最大HPと同じに。
        _currentHp = _maxHp;
        Debug.Log("Start currentHp : " + _currentHp);
    }

    /// <summary> ダメージが与えられたときは1,回復したときは-1を入れてください </summary>
    /// <param name="damage"></param>
    public override void Damage(int damage)
    {
        base.Damage(damage);
        _image.sprite = _hpImageList[_currentHp - 1];
    }
}
