using GameJamProject.Health;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(SpriteRenderer))]
public class Window : MonoBehaviour, IDamageable
{
    public WindowData WindowData;

    SpriteRenderer _spriteRenderer;

    public void ChangeSprite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }

    public void Heal(int amount)
    {
    }

    public void TakeDamage(int amount)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
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
