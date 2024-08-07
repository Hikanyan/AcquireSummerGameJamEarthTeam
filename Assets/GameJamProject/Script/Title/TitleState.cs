using GameJamProject.Audio;
using GameJamProject.System;
using UnityEngine;

namespace GameJamProject.Script.Title
{
    public class TitleState : State
    {
        public override async void OnEnter()
        {
            Debug.Log("Entered Title State");
            // タイトルシーンの初期化処理をここに追加
            await SceneManagement.SceneManager.Instance.LoadScene("TitleScene");
            AudioManager.Instance.PlayBGM("brightening");
        }

        public override void OnExit()
        {
            Debug.Log("Exited Title State");
            // タイトルシーンの終了処理をここに追加
            AudioManager.Instance.StopBGM();
        }

        public override void OnUpdate(float deltaTime)
        {
            // タイトルシーンの更新処理をここに追加
        }
    }
}