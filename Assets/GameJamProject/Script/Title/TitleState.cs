using System;
using GameJamProject.Audio;
using GameJamProject.System;
using UniRx;
using UnityEngine;

namespace GameJamProject.Script.Title
{
    public class TitleState : MonoBehaviour
    {
        public void Start()
        {
            AudioManager.Instance.PlayBGM("brightening");
            // 時間経過でオープニングに遷移
            Observable.Timer(TimeSpan.FromSeconds(30)).Subscribe(async _ =>
            {
                await SceneManagement.SceneManager.Instance.LoadScene("Opening");
            }).AddTo(this);
        }

        public void OnDestroy()
        {
            // タイトルシーンの終了処理をここに追加
            AudioManager.Instance.StopBGM();
        }
    }
}