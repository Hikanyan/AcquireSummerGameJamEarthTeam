using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    private Transform _playerTransform;

    /// <summary>カーソルのポジションを取得します</summary>
    public Transform CursorTransform => transform;

    void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = new Vector3(_playerTransform.position.x, transform.position.y, transform.position.z);
    }
}