using GameJamProject.Audio;
using GameJamProject.System;
using UnityEngine;

namespace GameJamProject.Script.InGame
{
    public class InGameState : MonoBehaviour
    {
        public async void Start()
        {
            Debug.Log("Entered In-Game State");
            // ゲーム中シーンの初期化処理をここに追加
            AudioManager.Instance.PlayBGM("chasing");
        }

        public void OnDestroy()
        {
            Debug.Log("Exited In-Game State");
            // ゲーム中シーンの終了処理をここに追加
            AudioManager.Instance.StopBGM();
            SaveManager.Instance.Save();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public void Update()
        {
            // ゲーム中シーンの更新処理をここに追加

            // ゲームオーバー条件を満たした場合
            // if (true)
            // {
            //     // ゲームオーバーシーンに遷移
            //     GameController.Instance.ChangeGameState(GameState.GameOver);
            // }
        }
    }
}