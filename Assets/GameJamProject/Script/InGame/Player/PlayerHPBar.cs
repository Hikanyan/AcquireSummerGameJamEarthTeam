using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : PlayerParameter
{
    //最大HPと現在のHP。
    PlayerParameter _maxHp = default;
    PlayerParameter _currentHp = default;
    //Sliderを入れる
    public Slider _slider;

    void Start()
    {
        //Sliderを満タンにする。
        _slider.value = 1;
        //現在のHPを最大HPと同じに。
        _currentHp = _maxHp;
        Debug.Log("Start currentHp : " + _currentHp);
    }

    //ColliderオブジェクトのIsTriggerにチェック入れること。
    private void OnTriggerEnter(Collider collider)
    {
        //Enemyタグのオブジェクトに触れると発動
        if (collider.gameObject.tag == " ")
        {
            //ダメージは1～100の中でランダムに決める。
            int damage = Random.Range(1, 100);
            Debug.Log("damage : " + damage);

            //現在のHPからダメージを引く
            //_currentHp = currentHp - damage;
            Debug.Log("After currentHp : " + _currentHp);

            //最大HPにおける現在のHPをSliderに反映。
            //int同士の割り算は小数点以下は0になるので、
            //(float)をつけてfloatの変数として振舞わせる。
            //slider.value = (float)currentHp / (float)maxHp; ;
            Debug.Log("slider.value : " + _slider.value);
        }
    }
}
