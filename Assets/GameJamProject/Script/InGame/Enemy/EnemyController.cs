using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] WindowData[] _windowDataBase;
    [SerializeField] float _interval = 3;
    [SerializeField] int _row = 3;
    [SerializeField] int _column = 3;
    [SerializeField] int _peopleCount = 3;

    List<List<WindowData>> _windows = new List<List<WindowData>>();
    float _currentTime;

    void Start()
    {
        for (int y = 0; y < _row; y++)
        {
            _windows.Add(new List<WindowData>());

            for (int x = 0; x < _column; x++)
            {
                _windows[y].Add(_windowDataBase[0]);
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
            // _peopleCount‚ð”Õ–Ê‚Ì”-1ˆÈã‚É‚µ‚È‚¢‚ÅII
            do
            {
                peopleposition[i] = new Vector2(Random.RandomRange(0, _row), Random.RandomRange(0, _column));
            }
            while (peopleposition[i].x == targetPosition.x && peopleposition[i].y == targetPosition.y);
        }

        for (int y = 0; y < _row; y++)
        {
            for (int x = 0; x < _column; x++)
            {
                if (targetPosition.x == x && targetPosition.y == y)
                {
                    //Debug.Log($"TargetPosition\nx : {x}\ny : {y}");
                    _windows[x][y] = _windowDataBase[1];
                }
                else if (peopleposition.Contains(new Vector2(x, y)))
                {
                    //Debug.Log($"Peopleposition\nx : {x}\ny : {y}");
                    _windows[x][y] = _windowDataBase[2];
                }
                else
                {
                    _windows[x][y] = _windowDataBase[0];
                }
            }
        }
    }
}


[System.Serializable]
public class WindowData
{
    [SerializeField] WindowSate windowSate;
    [SerializeField] Sprite windowSprite;

    public WindowSate WindowSate => windowSate;
    public Sprite WindowSprite => windowSprite;
}

public enum WindowSate
{
    None,
    Target,
    People,
}