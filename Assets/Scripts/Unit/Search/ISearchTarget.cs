// 日本語対応
using System;

namespace TeamB_TD
{
    namespace Unit
    {
        namespace Search
        {
            public interface ISearchTarget // 索敵対象であることを表現する。
            {
                UnitType UnitType { get; } // 自身のユニットの種類を表現する値。
                Action<ISearchTarget> OnDead { get; set; }
                IDamageable GetDamageable();

                int TargetCount { get; }
                void Target();
                void LostTarget();
            }
        }
    }
}