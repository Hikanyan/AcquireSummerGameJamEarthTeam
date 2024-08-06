using UnityEngine;
using UnityEngine.InputSystem;

public class PlyerController : MonoBehaviour
{
    [SerializeField] float _playerSpeed = 0.5F;
    private Vector2 _min;
    private Vector2 _max;

    private Vector2 _inputMove;

    private Transform _transform;
    private CharacterController _characterController;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        _min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        _max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
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
        var moveVelocity = new Vector3(_inputMove.x * _playerSpeed, 0, 0);
        var moveDelta = moveVelocity * Time.deltaTime;
        _characterController.Move(moveVelocity);
    }

    /// <summary>
    /// 取得したアイテムを生成
    /// </summary>
    /// <param name="item"></param>
    public void SelectItem(GameObject item)
    {
        var bulletGb = Instantiate(item, transform.position + transform.forward, item.transform.rotation);
    }
}
