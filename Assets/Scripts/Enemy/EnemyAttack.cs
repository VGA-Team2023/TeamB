using UnityEngine;
using TeamB_TD.Unit;
using TeamB_TD.Unit.Search;
using System;
using System.Collections.Generic;
using System.Linq;

//日本語対応
namespace TeamB_TD
{
    namespace Enemy
    {
        public class EnemyAttack : MonoBehaviour, IDamageable, ISearchTarget, ISearcher
        {
            public UnitType UnitType => UnitType.Enemy;

            public event Action<ISearchTarget> OnDead;

            public int TargetCount => _targetCount;

            public UnitType TargetType => UnitType.Enemy;

            public bool IsExistTarget => _targetCount == 0;

            private EnemyStatus _status = new EnemyStatus();

            private int _targetCount = 0;

            private void Start()
            {
                if (TryGetComponent(out EnemyController controller))
                {
                    _status = controller.EnemyStatus;
                }
                _status.Recover(_status.MaxLife);
                
                if(TryGetComponent(out MeshRenderer renderer)) renderer.material.color = Color.white;
            }

            public void Damage(float value)
            {
                _status.Damage(value);
                Debug.Log($"{_status.CurrentLife}");

                if (_status.CurrentLife <= 0)
                {
                    OnDead?.Invoke(this);
                    Destroy(gameObject);
                    Debug.Log("Dead");
                }
            }

            public IDamageable GetDamageable() => this;

            public void Target()
            {
                _targetCount++;

                if (_targetCount > 0)
                {
                    if(TryGetComponent(out MeshRenderer rend)) rend.material.color = Color.red;
                }
            }

            public void LostTarget()
            {
                _targetCount--;

                if (_targetCount <= 0)
                {
                    if (TryGetComponent(out MeshRenderer rend)) rend.material.color = Color.white;
                }
            }

            public void Initialize(GameObject gameObject)
            {
                
            }

            public IReadOnlyList<ISearchTarget> GetTargets()
            {
                List<ISearchTarget> _targets = new List<ISearchTarget>() { this };
                return _targets;
            }
        }
    }
}