using GameJamProject.Audio;
using GameJamProject.System;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace GameJamProject.Script.Result
{
    public class ResultState : State
    {
        public override async void OnEnter()
        {
            Debug.Log("Entered Result State");
            // 結果シーンの初期化処理をここに追加
            await SceneManagement.SceneManager.Instance.LoadScene("ResultScene");
            AudioManager.Instance.PlayBGM("configClear");
        }

        public override void OnExit()
        {
            Debug.Log("Exited Result State");
            // 結果シーンの終了処理をここに追加
            AudioManager.Instance.StopBGM();
        }

        public override void OnUpdate(float deltaTime)
        {
            // 結果シーンの更新処理をここに追加
        }
    }
}