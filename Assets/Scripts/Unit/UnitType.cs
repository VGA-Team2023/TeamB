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
            Ally = 1,
            Enemy = 2,
            Tower = 4,
        }
    }
}