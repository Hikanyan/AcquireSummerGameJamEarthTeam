using UnityEngine;

public class PlyerController : MonoBehaviour
{
    private float _playerSpeed = 10.0F;
    private Vector2 _min;
    private Vector2 _max;

    void Start()
    {
        _min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        _max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Update()
    {
        Move();
    }

    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    private void Move()
    {
        
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * _playerSpeed;
        transform.position += new Vector3(x, 0, 0);

        Vector3 currentPos = transform.position;

        currentPos.x = Mathf.Clamp(currentPos.x, _min.x, _max.x);

        transform.position = currentPos;
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
