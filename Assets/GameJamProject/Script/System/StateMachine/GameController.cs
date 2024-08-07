using GameJamProject.Script.GameOver;
using GameJamProject.Script.InGame;
using GameJamProject.Script.Result;
using GameJamProject.Script.Title;
using GameJamProject.System;

namespace GameJamProject.System
{
    public class GameController : Singleton<GameController>
    {
        private StateMachine _stateMachine;

        protected override void OnAwake()
        {
            base.OnAwake();
            _stateMachine = gameObject.AddComponent<StateMachine>();

            // 初期状態をTitleStateに設定
            ChangeGameState(GameState.None);
        }

        private void Update()
        {
            // 状態の更新
            _stateMachine.Update();
        }

        public void ChangeGameState(GameState newState)
        {
            switch (newState)
            {
                case GameState.Title:
                    _stateMachine.ChangeState(new TitleState());
                    break;
                case GameState.InGame:
                    _stateMachine.ChangeState(new InGameState());
                    break;
                case GameState.Result:
                    _stateMachine.ChangeState(new ResultState());
                    break;
                case GameState.GameOver:
                    _stateMachine.ChangeState(new GameOverState());
                    break;
            }
        }
    }
}