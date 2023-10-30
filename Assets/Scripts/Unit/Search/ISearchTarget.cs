// 日本語対応
using System;
using UnityEngine;

namespace TeamB_TD
{
    namespace Unit
    {
        namespace Search
        {
            public interface ISearchTarget // 索敵対象であることを表現する。
            {
                GameObject GameObject { get; }
                UnitType UnitType { get; } // 自身のユニットの種類を表現する値。
                event Action<ISearchTarget> OnDead;
                IDamageable GetDamageable();

                int TargetCount { get; }
                void Target();
                void LostTarget();
            }
        }
    }
}