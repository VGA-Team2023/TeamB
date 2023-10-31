using System;
using TeamB_TD.Unit;
using TeamB_TD.Unit.Search;
using UnityEngine;

//日本語対応
namespace TeamB_TD
{
    namespace Enemy
    {
        public class EnemyLifeManager : MonoBehaviour, IDamageable, ISearchTarget
        {
            private EnemyStatus _status;
            private int _targetCount = 0;

            public UnitType UnitType => UnitType.Enemy;
            public int TargetCount => _targetCount;

            public GameObject GameObject => this.gameObject;

            public event Action<ISearchTarget> OnDead;

            private void Start()
            {
                if (TryGetComponent(out EnemyController controller))
                {
                    _status = controller.EnemyStatus;
                }
                _status.Heal(_status.MaxLife);

                if (TryGetComponent(out MeshRenderer renderer)) renderer.material.color = Color.white;
            }

            public void Damage(float value)
            {
                _status.Damage(value);
                // Debug.Log($"Damage: {gameObject.name} {_status.CurrentLife}");

                if (_status.CurrentLife <= 0)
                {
                    OnDead?.Invoke(this);
                    Debug.Log("Dead");
                    Battle.GameManager.Current.AddCompletedEnemyCount(_status);
                    Destroy(gameObject);
                }
            }

            public IDamageable GetDamageable() => this;

            public void Target()
            {
                _targetCount++;

                if (_targetCount > 0)
                {
                    if (TryGetComponent(out MeshRenderer rend)) rend.material.color = Color.red;
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
        }
    }
}