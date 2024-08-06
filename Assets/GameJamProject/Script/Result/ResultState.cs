using GameJamProject.System;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace GameJamProject.Script.Result
{
    public class ResultState : State
    {
        public override void OnEnter()
        {
            Debug.Log("Entered Result State");
            // 結果シーンの初期化処理をここに追加
        }

        public override void OnExit()
        {
            Debug.Log("Exited Result State");
            // 結果シーンの終了処理をここに追加
        }

        public override void OnUpdate(float deltaTime)
        {
            // 結果シーンの更新処理をここに追加
        }
    }
}