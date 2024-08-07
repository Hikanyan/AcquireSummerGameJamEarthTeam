using GameJamProject.Audio;
using GameJamProject.System;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace GameJamProject.Script.Result
{
    public class ResultState : MonoBehaviour
    {
        public async void Start()
        {
            await SceneManagement.SceneManager.Instance.LoadScene("ResultScene");
            AudioManager.Instance.PlayBGM("configClear");
        }

        public void OnDestroy()
        {
            Debug.Log("Exited Result State");
            // 結果シーンの終了処理をここに追加
            AudioManager.Instance.StopBGM();
        }

        public  void Update()
        {
            
        }
    }
}