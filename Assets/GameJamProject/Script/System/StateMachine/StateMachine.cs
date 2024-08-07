using UnityEngine;

namespace GameJamProject.System
{
    // 状態管理クラス
    public class StateMachine
    {
        private State _currentState;

        public void ChangeState(State newState)
        {
            if (_currentState != null)
            {
                _currentState.OnExit();
            }

            _currentState = newState;
            if (_currentState != null)
            {
                _currentState.OnEnter();
            }
        }

        public void Update()
        {
            if (_currentState != null)
            {
                _currentState.OnUpdate(Time.deltaTime);
            }
        }
    }
}