// 日本語対応
using System;
using TeamB_TD.Unit.Search;

namespace TeamB_TD.Unit.Ally
{
    public interface IAllyMain
    {
        AllyStatus AllyStatus { get; }
        ISearcher Searcher { get; }
        int TargetCount { get; }
        UnitType UnitType { get; }

        event Action<ISearchTarget> OnDead;

        void Damage(float value);
        IDamageable GetDamageable();
        void LostTarget();
        void Target();
    }
}