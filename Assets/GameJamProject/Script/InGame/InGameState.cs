using GameJamProject.System;
using UnityEngine;

namespace GameJamProject.Script.InGame
{
    public class InGameState : State
    {
        public override void OnEnter()
        {
            Debug.Log("Entered In-Game State");
            // ゲーム中シーンの初期化処理をここに追加
        }

        public override void OnExit()
        {
            Debug.Log("Exited In-Game State");
            // ゲーム中シーンの終了処理をここに追加
        }

        public override void OnUpdate(float deltaTime)
        {
            // ゲーム中シーンの更新処理をここに追加
        }
    }
}