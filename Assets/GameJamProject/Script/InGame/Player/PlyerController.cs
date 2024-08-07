using GameJamProject.Audio;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlyerController : MonoBehaviour
{
    [SerializeField] float _playerSpeed = 10.0F;
    [SerializeField] Vector2 _min = new Vector2();
    [SerializeField] Vector2 _max = new Vector2();
    [SerializeField] List<GameObject> _items;

    [SerializeField] PlayerHp _playerHp;

    private Vector2 _inputMove;

    private Transform _transform;
    private CharacterController _characterController;

    private GameObject _parentBullet;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
 
        _parentBullet = new GameObject("ParentBullet");
        SceneManager.MoveGameObjectToScene(_parentBullet, gameObject.scene);
    }

    private void Awake()
    {
        _transform = transform;
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    /// <summary>
    /// 移動Action(PlayerInput側から呼ばれる)
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        _inputMove = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    public void Move()
    {
        Vector3 playerPos = _characterController.transform.position;

        var moveVelocity = new Vector3(_inputMove.x * _playerSpeed, 0, 0);
        var moveDelta = moveVelocity * Time.deltaTime;

        Vector3 newPostion = playerPos + moveDelta;

        newPostion.x = Mathf.Clamp(newPostion.x, _min.x, _max.x);

        _characterController.Move(newPostion - playerPos);
    }

    /// <summary>
    /// アイテム発射Action(PlayerInputから呼ばれる)
    /// </summary>
    /// <param name="context"></param>
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SelectItem(_items[Random.Range(0, _items.Count)]);
            AudioManager.Instance.PlaySE("大砲2");
        }
    }

    /// <summary>
    /// 取得したアイテムを生成
    /// </summary>
    /// <param name="item"></param>
    public void SelectItem(GameObject item)
    {
        var bulletGb = Instantiate(item, transform.position + transform.forward, item.transform.rotation);
        SceneManager.MoveGameObjectToScene(bulletGb, gameObject.scene);
        bulletGb.transform.parent = _parentBullet.transform;
    }
}