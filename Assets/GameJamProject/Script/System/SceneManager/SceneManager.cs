using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using GameJamProject.System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameJamProject.SceneManager
{
    public class SceneManager : Singleton<SceneManager>
    {
        protected override bool UseDontDestroyOnLoad => true;

        private Scene _lastScene;
        private SceneLoader _sceneLoader;
        private string _neverUnloadSceneName = "ManagerScene";
        private IFadeStrategy _fadeStrategy;
        private readonly Stack<string> _sceneHistory = new Stack<string>();

        [SerializeField] private Material _fadeMaterial; // フェードマテリアル

        public Material FadeMaterial => _fadeMaterial; // フェードマテリアルの公開プロパティ

        private async void Start()
        {
            // 初期化処理
            _sceneLoader = new SceneLoader();
            _fadeStrategy = new BasicFadeStrategy();

            // ManagerSceneを必ずロードする
            await LoadNeverUnloadSceneAsync();
        }

        private async UniTask LoadNeverUnloadSceneAsync()
        {
            await _sceneLoader.LoadSceneAsync(_neverUnloadSceneName, LoadSceneMode.Additive);
        }

        public async UniTask LoadSceneWithFade(string sceneName, Material fadeMaterial, float fadeDuration,
            float cutoutRange, Ease ease, bool recordHistory = true)
        {
            await _fadeStrategy.FadeOut(fadeMaterial, fadeDuration, cutoutRange, ease);
            await _sceneLoader.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            if (recordHistory && !_sceneLoader.IsSceneLoaded(sceneName))
            {
                _sceneHistory.Push(sceneName);
            }

            await _fadeStrategy.FadeIn(fadeMaterial, fadeDuration, cutoutRange, ease);
        }

        public async UniTask UnloadSceneWithFade(string sceneName, Material fadeMaterial, float fadeDuration,
            float cutoutRange, Ease ease)
        {
            if (sceneName == _neverUnloadSceneName)
            {
                Debug.LogWarning($"Cannot unload the never unload scene: {sceneName}");
                return;
            }

            await _fadeStrategy.FadeOut(fadeMaterial, fadeDuration, cutoutRange, ease);
            await _sceneLoader.UnloadSceneAsync(sceneName);
            await _fadeStrategy.FadeIn(fadeMaterial, fadeDuration, cutoutRange, ease);
        }

        public async UniTask ReloadSceneWithFade(Material fadeMaterial, float fadeDuration, float cutoutRange,
            Ease ease)
        {
            if (_sceneHistory.Count > 0)
            {
                string currentScene = _sceneHistory.Pop();
                await UnloadSceneWithFade(currentScene, fadeMaterial, fadeDuration, cutoutRange, ease);
                await LoadSceneWithFade(currentScene, fadeMaterial, fadeDuration, cutoutRange, ease, false);
            }
        }

        public async UniTask LoadPreviousSceneWithFade(Material fadeMaterial, float fadeDuration, float cutoutRange,
            Ease ease)
        {
            if (_sceneHistory.Count > 1)
            {
                string currentScene = _sceneHistory.Pop();
                string previousScene = _sceneHistory.Peek();
                await UnloadSceneWithFade(currentScene, fadeMaterial, fadeDuration, cutoutRange, ease);
                await LoadSceneWithFade(previousScene, fadeMaterial, fadeDuration, cutoutRange, ease, false);
            }
        }

        public async UniTask LoadScene(string sceneName, bool recordHistory = true)
        {
            await _sceneLoader.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            if (recordHistory && !_sceneLoader.IsSceneLoaded(sceneName))
            {
                _sceneHistory.Push(sceneName);
            }
        }

        public async UniTask UnloadScene(string sceneName)
        {
            if (sceneName == _neverUnloadSceneName)
            {
                Debug.LogWarning($"Cannot unload the never unload scene: {sceneName}");
                return;
            }

            await _sceneLoader.UnloadSceneAsync(sceneName);
        }
    }
}