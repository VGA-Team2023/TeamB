// 日本語対応
using System;

namespace TeamB_TD
{
    namespace StageManagement
    {
        [Serializable, Flags]
        public enum CellStatus : int
        {
            None = 0,
            Movable = 1,  // 通行可能
            Placeable = 2, // ユニット配置可能
            EnemySpawner = 4,
            Tower = 8,
        }
    }
}