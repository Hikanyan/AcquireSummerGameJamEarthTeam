using UnityEngine;

namespace GameJamProject.System
{
    // 状態管理クラス
    public class StateMachine : MonoBehaviour
    {
        private State currentState;

        public void ChangeState(State newState)
        {
            if (currentState != null)
            {
                currentState.OnExit();
            }

            currentState = newState;
            if (currentState != null)
            {
                currentState.OnEnter();
            }
        }

        private void Update()
        {
            if (currentState != null)
            {
                currentState.OnUpdate(Time.deltaTime);
            }
        }
    }
}