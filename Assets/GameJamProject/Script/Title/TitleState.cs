using System;
using GameJamProject.Audio;
using GameJamProject.System;
using UnityEngine;

namespace GameJamProject.Script.Title
{
    public class TitleState : MonoBehaviour
    {
        public async void Start()
        {
            await SceneManagement.SceneManager.Instance.LoadScene("TitleScene");
            AudioManager.Instance.PlayBGM("brightening");
        }

        public void OnDestroy()
        {
            // タイトルシーンの終了処理をここに追加
            AudioManager.Instance.StopBGM();
        }
    }
}