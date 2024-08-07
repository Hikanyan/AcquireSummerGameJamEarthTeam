using GameJamProject.Health;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Window : MonoBehaviour, IDamageable
{
    public WindowData WindowData;

    public void Heal(int amount)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {

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
