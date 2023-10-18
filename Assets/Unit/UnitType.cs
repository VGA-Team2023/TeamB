// 日本語対応
using System;

namespace TeamB_TD
{
    namespace Unit
    {
        [Serializable]
        [Flags]
        public enum UnitType : int
        {
            None = 0,
            Everything = -1,
            Ally = 1,
            Enemy = 2,
        }
    }
}