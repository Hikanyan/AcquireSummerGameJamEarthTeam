using UnityEngine;
using UnityEngine.UI;

public class MeterController : MonoBehaviour
{
    [SerializeField] Slider _merter;
    
    void Start()
    {
        _merter.value = 0;
    }

    
    void Update()
    {
        float t = 2.0f;
        float f = 1.0f / t;
        float sin = Mathf.Abs(Mathf.Sin(2 * Mathf.PI * f * Time.time));
        _merter.value = sin;
    }
}
