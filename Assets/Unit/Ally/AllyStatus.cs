// 日本語対応
using UnityEngine;
using System;
using TeamB_TD.Unit.Search;
using System.Collections.Generic;

namespace TeamB_TD
{
    namespace Unit
    {
        namespace Ally
        {
            [Serializable]
            public struct AllyStatus
            {
                public AllyStatus(float cost, float maxLife, float currentLife, float attackPower, float attackInterval, float attackIntervalTimer)
                {
                    _cost = cost;
                    _maxLife = maxLife;
                    _currentLife = currentLife;
                    _attackPower = attackPower;
                    _attackInterval = attackInterval;
                    _attackIntervalTimer = attackIntervalTimer;

                    _searcher = null;
                    _attackTargets = null;
                }

                [SerializeField]
                private float _cost;
                [SerializeField]
                private float _maxLife;
                [SerializeField]
                private float _attackPower;
                [SerializeField]
                private float _attackInterval;

                [SerializeField]
                //[HideInInspector]
                private float _currentLife;
                [SerializeField]
                //[HideInInspector]
                private float _attackIntervalTimer;

                public float Cost => _cost;
                public float MaxLife => _maxLife;
                public float CurrentLife => _currentLife;
                public float AttackPower => _attackPower;
                public float AttackInterval => _attackInterval;
                public float AttackIntervalTimer => _attackIntervalTimer;

                public bool IsAttackable => _attackIntervalTimer <= 0f && _searcher.IsExistTarget;
                public bool IsDead => _currentLife <= 0f;

                private ISearcher _searcher;
                private List<ISearchTarget> _attackTargets;

                public void Initialize(ISearcher searcher)
                {
                    _searcher = searcher;
                    _attackTargets = new List<ISearchTarget>();
                }

                public void Damage(float value)
                {
                    _currentLife -= value;

                    if (_currentLife < 0) _currentLife = 0;
                }

                public void Heal(float value)
                {
                    _currentLife += value;

                    if (_currentLife > _maxLife) _currentLife = _maxLife;
                }

                public void Attack(IReadOnlyList<ISearchTarget> targets)
                {
                    _attackIntervalTimer = _attackInterval;

                    foreach (var target in targets)
                    {
                        target.GetDamageable().Damage(_attackPower);
                    }
                }

                public void Clear()
                {
                    _currentLife = _maxLife;
                    _attackIntervalTimer = _attackInterval;
                }

                public void Update(float deltaTime)
                {
                    _attackTargets.Clear();
                    _attackTargets.AddRange(_searcher.GetTargets());

                    if (IsAttackable)
                    {
                        Attack(_attackTargets);
                    }

                    _attackIntervalTimer -= deltaTime;
                    if (_attackIntervalTimer < 0f) _attackIntervalTimer = 0f;
                }
            }
        }
    }
}