// 日本語対応
using System.Collections.Generic;
using UnityEngine;

namespace TeamB_TD
{
    namespace Unit
    {
        namespace Search
        {
            public interface ISearcher // 索敵することが可能であることを表現する。
            {
                void Initialize(GameObject gameObject);
                UnitType TargetType { get; } // 標的となるユニットの種類。
                IReadOnlyList<ISearchTarget> GetTargets(); // エリア内のターゲットを取得する処理
                bool IsExistTarget { get; }
                void OnDead();
            }
        }
    }
}