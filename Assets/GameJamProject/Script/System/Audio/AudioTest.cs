using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameJamProject.Audio
{
    public class AudioTest : MonoBehaviour
    {
        private async void Start()
        {
            // BGM再生
            AudioManager.Instance.PlayBGM("brightening");

            // 2秒待機
            await UniTask.Delay(2000);

            // BGM停止
            AudioManager.Instance.StopBGM();

            // 2秒待機
            await UniTask.Delay(2000);

            // BGM再生
            AudioManager.Instance.PlayBGM("brightening");
        }
    }
}