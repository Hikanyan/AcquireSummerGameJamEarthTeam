using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] WindowData[] _data;
    [SerializeField] float _interval = 3;
    [SerializeField] int _row = 3;
    [SerializeField] int _column = 3;
    [SerializeField] int _peopleCount = 3;

    SpriteRenderer spriteRenderer;
    List<List<Window>> _windows = new List<List<Window>>();
    float _currentTime;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // 窓はこのコンポーネントの子オブジェクトにある前提
        Window[] windows = GetComponentsInChildren<Window>();
        int windowCount = 0;

        for (int y = 0; y < _row; y++)
        {
            _windows.Add(new List<Window>());

            for (int x = 0; x < _column; x++)
            {
                if (windowCount >= windows.Length) break;

                _windows[y].Add(windows[windowCount]);
                windowCount++;
            }
        }

        _currentTime = _interval;
    }

    private void OnTriggerEnter(Collider other)
    {

    }


    void Update()
    {
        if (_currentTime > _interval)
        {
            EnemiesSetting();
            //Debug.Log(_windows[2][6].WindowData);
            _currentTime = 0;
        }
        else
        {
            _currentTime += Time.deltaTime;
        }
    }

    public void EnemiesSetting()
    {
        Vector2 targetPosition = new Vector2(Random.RandomRange(0, _row), Random.RandomRange(0, _column));
        Debug.Log($"TargetPositionGenerate\nx : {targetPosition.x} y : {targetPosition.y}");
        Vector2[] peopleposition = new Vector2[_peopleCount];

        for (int i = 0; i < _peopleCount; i++)
        {
            // _peopleCountを盤面の数-1以上にしないで！！
            do
            {
                peopleposition[i] = new Vector2(Random.RandomRange(0, _windows.Count), Random.RandomRange(0, _windows[i].Count));
                Debug.Log($"PeoplepositionGenerate\nx : {peopleposition[i].x} y : {peopleposition[i].y}");
            }
            while (peopleposition[i].x == targetPosition.x && peopleposition[i].y == targetPosition.y);
        }

        for (int y = 0; y < _windows.Count; y++)
        {
            for (int x = 0; x < _windows[y].Count; x++)
            {
                if (targetPosition.x == y && targetPosition.y == x)
                {
                    _windows[y][x].WindowData = _data[1];
                    _windows[y][x].ChangeSprite(_data[1].WindowSprite);
                    
                    Debug.Log($"TargetPosition\nx : {x} y : {y}");
                }
                else if (peopleposition.Contains(new Vector2(x, y)))
                {
                    _windows[y][x].WindowData = _data[2];
                    _windows[y][x].ChangeSprite(_data[2].WindowSprite);
                    Debug.Log($"Peopleposition\nx : {x} y : {y}");
                }
                else
                {
                    _windows[y][x].WindowData = _data[0];
                    _windows[y][x].ChangeSprite(_data[0].WindowSprite);
                }
            }
        }
    }
}

