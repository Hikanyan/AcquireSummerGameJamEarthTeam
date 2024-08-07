using UnityEngine;
using UnityEngine.UI;

public class CursorController : MonoBehaviour
{
    [SerializeField] private float _maxY;
    [SerializeField] private Slider _meater;

    private Transform _playerTransform;

    /// <summary>カーソルの Transform を取得します</summary>
    public Transform CursorTransform => transform;

    void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = new Vector3(_playerTransform.position.x,
            _playerTransform.position.y + _maxY * _meater.value,
            transform.position.z);
    }
}