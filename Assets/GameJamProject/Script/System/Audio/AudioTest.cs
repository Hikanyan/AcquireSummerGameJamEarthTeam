using UnityEngine;

namespace GameJamProject.Audio
{
    public class AudioTest : MonoBehaviour
    {
        public AudioClip _bgmClip;
        public AudioClip _seClip;
        public AudioClip _voiceClip;

        private void Start()
        {
            // BGM再生
            AudioManager.Instance.PlayBGM(_bgmClip);

            // SE再生
            //AudioManager.Instance.PlaySE(_seClip);

            // Voice再生
            //AudioManager.Instance.PlayVoice(_voiceClip);
        }
    }
}