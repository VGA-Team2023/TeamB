// 日本語対応
using Glib.HitSupport;
using System.Collections.Generic;
using TeamB_TD.Unit.Search;
using UnityEngine;

namespace TeamB_TD
{
    namespace Unit
    {
        namespace Ally
        {
            public class AllySampleSearch : ISearcher
            {
                [SerializeField]
                private UnitType _targetType;
                [SerializeField]
                private OverLabBoxNonAlloc _overLabBox;

                private readonly List<ISearchTarget> _targets = new List<ISearchTarget>();
                private Transform _origin = null;

                public UnitType TargetType => _targetType;

                public void Initialize(GameObject gameObject)
                {
                    _origin = gameObject.transform;
                }

                public bool IsExistTarget
                {
                    get
                    {
                        return GetTargets().Count != 0;
                    }
                }

                public IReadOnlyList<ISearchTarget> GetTargets()
                {
                    foreach (var old in _targets)
                    {
                        old.OnDead -= OnDeadTarget;
                        old.LostTarget();
                    }

                    _targets.Clear();

                    var colliders = _overLabBox.GetOverlappingColliders(_origin, out int hitCount);

                    for (int i = 0; i < hitCount; i++)
                    {
                        if (colliders[i].TryGetComponent(out ISearchTarget target))
                        {
                            _targets.Add(target);
                            target.Target();
                            target.OnDead += OnDeadTarget;
                        }
                    }

                    return _targets;
                }

                // 補足中の敵が死んだらターゲットリストから除外する。
                private void OnDeadTarget(ISearchTarget target)
                {
                    target.OnDead -= OnDeadTarget;
                    _targets.Remove(target);
                }
            }
        }
    }
}