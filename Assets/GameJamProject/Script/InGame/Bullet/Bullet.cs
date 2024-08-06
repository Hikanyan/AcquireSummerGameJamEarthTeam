using GameJamProject.Health;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody))]
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
        
        if (rigidbody.useGravity)
        {
            rigidbody.useGravity = false;
        }
        
        Vector3 targetDir = Vector3.forward;
        CursorController cursorController = FindFirstObjectByType<CursorController>();

        if (cursorController is not null)
        {
            targetDir = (cursorController.CursorTransform.position - transform.position).normalized;
        }

        rigidbody.velocity = targetDir * _bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        var damegeable = other.gameObject.GetComponent<IDamageable>();

        if (damegeable is not null)
        {
            damegeable.TakeDamage(_damage);
        }
    }
}