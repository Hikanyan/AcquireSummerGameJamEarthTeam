using UnityEngine;
using UnityEngine.UI;

public class PlayerParameter : MonoBehaviour
{
    [SerializeField] protected float _maxHp = 3;

    protected float _currentHp;

    private void Awake()
    {
        _currentHp = _maxHp;
    }

    public void Damage(int damage)
    {
        _currentHp -= damage;
        //AudioManager.Instance.PlaySE("");
    }
}
