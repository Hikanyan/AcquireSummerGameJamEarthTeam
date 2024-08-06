using System;

namespace GameJamProject.System
{
    /// <summary>
    /// ペア
    /// </summary>
    [Serializable]
    public class Pair<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;

        public Pair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}