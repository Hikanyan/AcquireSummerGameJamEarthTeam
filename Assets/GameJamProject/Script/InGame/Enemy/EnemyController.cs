using GameJamProject.Health;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    [SerializeField] float _interval = 3;
    [SerializeField] int _row = 3;
    [SerializeField] int _column = 3;
    [SerializeField] int _peopleCount = 3;

    List<List<Window>> _windows = new List<List<Window>>();
    float _currentTime;

    void Start()
    {
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
        Vector2[] peopleposition = new Vector2[_peopleCount];

        for (int i = 0; i < _peopleCount; i++)
        {
            // _peopleCountを盤面の数-1以上にしないで！！
            do
            {
                peopleposition[i] = new Vector2(Random.RandomRange(0, _row), Random.RandomRange(0, _column));
            }
            while (peopleposition[i].x == targetPosition.x && peopleposition[i].y == targetPosition.y);
        }

        for (int y = 0; y < _windows.Count; y++)
        {
            for (int x = 0; x < _windows[y].Count; x++)
            {
                if (targetPosition.x == x && targetPosition.y == y)
                {
                    //Debug.Log($"TargetPosition\nx : {x}\ny : {y}");
                    _windows[x][y].WindowData.WindowSate = WindowSate.Target;
                }
                else if (peopleposition.Contains(new Vector2(x, y)))
                {
                    //Debug.Log($"Peopleposition\nx : {x}\ny : {y}");
                    _windows[x][y].WindowData.WindowSate = WindowSate.People;
                }
                else
                {
                    _windows[x][y].WindowData.WindowSate = WindowSate.None;
                }
            }
        }
    }

    public void TakeDamage(int amount)
    {
        throw new System.NotImplementedException();
    }

    public void Heal(int amount)
    {
    }
}

