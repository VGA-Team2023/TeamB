using System;
using TeamB_TD.Unit;
using TeamB_TD.Unit.Search;
using UnityEngine;

namespace TeamB_TD
{
    namespace TowerControl
    {
        public class Tower : UnitBehaviour, ISearchTarget, IDamageable
        {
            [SerializeField]
            private float _maxHp = 100f;
            [SerializeField]
            private float _currentHp = 0f;
            [SerializeField]
            private UnitType _unitType;

            public event Action<ISearchTarget> OnDead;

            public UnitType UnitType => _unitType;
            public float CurrentHp => _currentHp;
            public override string Name => "Tower";
            public override int Cost => 0;

            void Start()
            {
                Initialize();
            }

            private void Initialize()
            {
                _currentHp = _maxHp;
            }

            public void Damage(float value)
            {
                var old = _currentHp;
                _currentHp -= value;

                if (old > 0 && _currentHp <= 0f)
                {
                    OnDead?.Invoke(this);
                    Debug.Log("dead tower");
                }
            }

            public IDamageable GetDamageable()
            {
                return this;
            }

            private int _targetCount = 0;
            public int TargetCount => _targetCount;

            public GameObject GameObject => this.gameObject;

            public void Target()
            {
                _targetCount++;
            }

            public void LostTarget()
            {
                _targetCount--;
            }
        }
    }
}
