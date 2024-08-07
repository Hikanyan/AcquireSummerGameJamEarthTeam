using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameJamProject.Audio
{
    public class AudioTest : MonoBehaviour
    {
        private void Start()
        {
            // BGM再生
            AudioManager.Instance.PlayBGM("brightening");

            UniTask.Delay(2000);

            AudioManager.Instance.StopBGM();

            UniTask.Delay(2000);
            AudioManager.Instance.PlayBGM("brightening");
        }
    }
}