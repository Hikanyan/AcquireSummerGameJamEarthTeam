using GameJamProject.System;
using UnityEngine;

namespace GameJamProject.Script.GameOver
{
    public class GameOverState : State
    {
        public override void OnEnter()
        {
            Debug.Log("Entered Game Over State");
            // ゲームオーバーシーンの初期化処理をここに追加
        }

        public override void OnExit()
        {
            Debug.Log("Exited Game Over State");
            // ゲームオーバーシーンの終了処理をここに追加
        }

        public override void OnUpdate(float deltaTime)
        {
            // ゲームオーバーシーンの更新処理をここに追加
        }
    }
}