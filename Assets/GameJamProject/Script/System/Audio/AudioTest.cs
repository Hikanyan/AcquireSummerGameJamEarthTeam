using UnityEngine;

namespace GameJamProject.Audio
{
    public class AudioTest : MonoBehaviour
    {
        private void Start()
        {
            // BGM再生
            AudioManager.Instance.PlayBGM("brightening");

            // SE再生
            //AudioManager.Instance.PlaySE(_seClip);

            // Voice再生
            //AudioManager.Instance.PlayVoice(_voiceClip);
        }
    }
}