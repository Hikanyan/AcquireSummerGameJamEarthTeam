using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _damage;
    [SerializeField] private float _bulletSpeed;

    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = _sprite;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        CursorController cursorController = FindFirstObjectByType<CursorController>();
        Vector3 targetDir = cursorController.CursorPosition - transform.position;
        rigidbody.velocity = targetDir * _bulletSpeed;
    }
}
