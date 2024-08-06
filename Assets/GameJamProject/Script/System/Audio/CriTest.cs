using UnityEngine;

namespace GameJamProject.Audio
{
    public class CriTest : MonoBehaviour
    {
        [SerializeField] private string _bgmName;

        private void Start()
        {
            CriAudioManager.Instance.PlayBGM(_bgmName);
        }
    }
}