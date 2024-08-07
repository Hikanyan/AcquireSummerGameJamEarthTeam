using GameJamProject.Audio;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlyerController : PlayerParameter
{
    [SerializeField] float _playerSpeed = 10.0F;
    [SerializeField] Vector2 _min = new Vector2();
    [SerializeField] Vector2 _max = new Vector2();
    [SerializeField] List<GameObject> _items;
    private Vector2 _inputMove;

    private Transform _transform;
    private CharacterController _characterController;
    private ItemManager _itemManager;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        _transform = transform;
        _characterController = GetComponent<CharacterController>();
        _itemManager = FindFirstObjectByType<ItemManager>();
    }

    void Update()
    {
        Move();
    }

    /// <summary>
    /// �ړ�Action(PlayerInput������Ă΂��)
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        _inputMove = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// �v���C���[�̈ړ�
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
    /// �A�C�e������Action(PlayerInput����Ă΂��)
    /// </summary>
    /// <param name="context"></param>
    public void OnFire(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            GameObject item = Instantiate(_itemManager.SelectItems[0], transform.position + transform.forward, _itemManager.SelectItems[0].transform.rotation);
            _itemManager.NextItem();
            AudioManager.Instance.PlaySE("��C2");
        }
    }

    /// <summary>
    /// �擾�����A�C�e���𐶐�
    /// </summary>
    /// <param name="item"></param>
    public void SelectItem(GameObject item)
    {
        var bulletGb = Instantiate(item, transform.position + transform.forward, item.transform.rotation);
    }
}
