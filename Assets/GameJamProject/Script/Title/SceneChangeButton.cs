using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace GameJamProject.Title
{
    public class SceneChangeButton : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            // シーン遷移処理
            SceneManagement.SceneManager.Instance.LoadScene("InGameScene").Forget();
        }
    }
}