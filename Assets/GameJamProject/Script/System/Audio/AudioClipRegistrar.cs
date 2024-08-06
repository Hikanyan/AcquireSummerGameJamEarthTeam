using System.Collections.Generic;
using UnityEngine;

namespace GameJamProject.Audio
{
    public class AudioClipRegistrar : MonoBehaviour
    {
        [SerializeField] private List<AudioClipEntry> _bgmClips;
        [SerializeField] private List<AudioClipEntry> _seClips;
        [SerializeField] private List<AudioClipEntry> _voiceClips;

        private void Start()
        {
            RegisterClips();
        }

        private void RegisterClips()
        {
            foreach (var entry in _bgmClips)
            {
                AudioManager.Instance.RegisterBGM(entry);
            }

            foreach (var entry in _seClips)
            {
                AudioManager.Instance.RegisterSE(entry);
            }

            foreach (var entry in _voiceClips)
            {
                AudioManager.Instance.RegisterVoice(entry);
            }
        }
    }
}