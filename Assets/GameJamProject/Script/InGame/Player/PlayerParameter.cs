using Cysharp.Threading.Tasks;
using UnityEngine;


public class PlayerParameter : MonoBehaviour
{
    [SerializeField] protected int _maxHp = 3;

    protected int _currentHp;

    private void Awake()
    {
        _currentHp = _maxHp;
    }

    public virtual void Damage(int damage)
    {
        if (_currentHp > 1) _currentHp -= damage;
        else
        {
            GameJamProject.SceneManagement.SceneManager.Instance.LoadScene("ResultScene").Forget();
        }
        //AudioManager.Instance.PlaySE("");
    }
}
