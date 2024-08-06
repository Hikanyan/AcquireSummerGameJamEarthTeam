using UnityEngine;
using GameJamProject.System;

namespace GameJamProject.Audio
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] private AudioSource _bgmSource;
        [SerializeField] private AudioSource _seSource;
        [SerializeField] private AudioSource _voiceSource;

        protected override bool UseDontDestroyOnLoad => true;

        private float _masterVolume = 1f;
        private float _bgmVolume = 1f;
        private float _seVolume = 1f;
        private float _voiceVolume = 1f;
        private const float Diff = 0.01f;

        public float MasterVolume
        {
            get => _masterVolume;
            set
            {
                if (!(_masterVolume + Diff < value) && !(_masterVolume - Diff > value)) return;
                _masterVolume = value;
                UpdateVolumes();
            }
        }

        public float BGMVolume
        {
            get => _bgmVolume;
            set
            {
                if (!(_bgmVolume + Diff < value) && !(_bgmVolume - Diff > value)) return;
                _bgmVolume = value;
                _bgmSource.volume = _bgmVolume * _masterVolume;
            }
        }

        public float SEVolume
        {
            get => _seVolume;
            set
            {
                if (!(_seVolume + Diff < value) && !(_seVolume - Diff > value)) return;
                _seVolume = value;
                _seSource.volume = _seVolume * _masterVolume;
            }
        }

        public float VoiceVolume
        {
            get => _voiceVolume;
            set
            {
                if (!(_voiceVolume + Diff < value) && !(_voiceVolume - Diff > value)) return;
                _voiceVolume = value;
                _voiceSource.volume = _voiceVolume * _masterVolume;
            }
        }

        private void UpdateVolumes()
        {
            _bgmSource.volume = _bgmVolume * _masterVolume;
            _seSource.volume = _seVolume * _masterVolume;
            _voiceSource.volume = _voiceVolume * _masterVolume;
        }

        public void PlayBGM(AudioClip clip, bool loop = true)
        {
            _bgmSource.clip = clip;
            _bgmSource.loop = loop;
            _bgmSource.Play();
        }

        public void StopBGM()
        {
            _bgmSource.Stop();
        }

        public void PlaySE(AudioClip clip)
        {
            _seSource.PlayOneShot(clip, _seVolume * _masterVolume);
        }

        public void PlayVoice(AudioClip clip)
        {
            _voiceSource.PlayOneShot(clip, _voiceVolume * _masterVolume);
        }
    }
}