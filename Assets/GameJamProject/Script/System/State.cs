namespace GameJamProject.System
{
    // 抽象的な状態クラス
    public abstract class State
    {
        public abstract void OnEnter();
        public abstract void OnExit();
        public abstract void OnUpdate(float deltaTime);
    }
}