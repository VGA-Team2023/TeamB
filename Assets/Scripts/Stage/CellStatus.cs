// 日本語対応
using System;

namespace TeamB_TD
{
    namespace Stage
    {
        [Serializable]
        [Flags]
        public enum CellStatus : int
        {
            Moveable = 1,  // 通行可能
            Placeable = 2, // ユニット配置可能
        }
    }
}