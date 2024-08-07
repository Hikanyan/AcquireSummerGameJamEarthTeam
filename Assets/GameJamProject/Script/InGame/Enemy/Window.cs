using GameJamProject.Audio;
using GameJamProject.Health;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(SpriteRenderer))]
public class Window : MonoBehaviour, IDamageable
{
    public WindowData WindowData;

    SpriteRenderer _spriteRenderer;
    ScoreController _scoreController;
    PlayerHp _playerHp;

    [SerializeField] GameObject _damageSprite = default;

    public void ChangeSprite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }

    public void Heal(int amount)
    {
    }

    public void TakeDamage(int amount)
    {
        AudioManager.Instance.PlaySE("�Ō�3");
        Instantiate(_damageSprite, transform.position, Quaternion.identity);

        switch (WindowData.WindowSate)
        {
            case WindowSate.Target:
                _scoreController.AddScore(1000);
                break;
            case WindowSate.People:
                _playerHp.Damage(amount);
                break;
                
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        _scoreController = FindFirstObjectByType<ScoreController>();
        _playerHp = FindFirstObjectByType<PlayerHp>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
}


[System.Serializable]
public class WindowData
{
    public WindowSate WindowSate;
    public Sprite WindowSprite;
}

public enum WindowSate
{
    None,
    Target,
    People,
}
