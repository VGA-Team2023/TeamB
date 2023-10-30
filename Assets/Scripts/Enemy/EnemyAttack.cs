// 日本語対応
using Glib.InspectorExtension;
using System.Collections.Generic;
using TeamB_TD.Unit.Search;
using UnityEngine;

namespace TeamB_TD
{
    namespace Enemy
    {
        public class EnemyAttack : MonoBehaviour
        {
            [SerializeReference, SubclassSelector]
            private ISearcher _searcher; // 味方ユニット補足用クラス

            private float _attackPower;
            private float _attackInterval;

            private float _attackTimer;

            private void Start()
            {
                var status = GetComponent<EnemyController>().EnemyStatus;
                _attackInterval = status.AttackInterval;
                _attackPower = status.AttackPower;
            }

            private void Update()
            {
                _attackTimer += Time.deltaTime;

                if (_attackTimer > _attackInterval)
                {
                    _attackTimer -= _attackInterval;
                    FireAll(_searcher.GetTargets());
                }
            }

            private readonly List<ISearchTarget> _fireTargets = new List<ISearchTarget>();

            private void FireAll(IReadOnlyList<ISearchTarget> targets)
            {
                _fireTargets.Clear();
                _fireTargets.AddRange(targets);
                foreach (ISearchTarget target in _fireTargets)
                {
                    Fire(target);
                }
            }

            private void Fire(ISearchTarget target)
            {
                target.GetDamageable().Damage(_attackPower);
            }
        }
    }
}