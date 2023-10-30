// 日本語対応
using Glib.InspectorExtension;
using System.Collections.Generic;
using TeamB_TD.Unit.Search;
using UnityEngine;
using UnityEngine.UIElements;

namespace TeamB_TD
{
    namespace Enemy
    {
        public class EnemyAttack : MonoBehaviour
        {
            [SerializeReference, SubclassSelector]
            private ISearcher _searcher; // 味方ユニット補足用クラス

            private LineRenderer _lineRenderer;

            private float _attackPower;
            private float _attackInterval;

            private float _attackTimer;

            private void Start()
            {
                var status = GetComponent<EnemyController>().EnemyStatus;
                _lineRenderer = GetComponent<LineRenderer>();
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
                DrawLine();
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

            private List<Vector3> _positions = new List<Vector3>();

            private void DrawLine()
            {
                _positions.Clear();
                _positions.Add(this.transform.position);
                var targets = _searcher.GetTargets();
                for (int i = 0; i < targets.Count; i++)
                {
                    if (targets[i].GameObject)
                        _positions.Add(targets[i].GameObject.transform.position);
                }

                _lineRenderer.positionCount = _positions.Count;
                _lineRenderer.SetPositions(_positions.ToArray());
            }

            private void OnDisable()
            {
                _searcher.OnDead();
            }
        }
    }
}