// 日本語対応
using UnityEngine;
using System.Collections.Generic;

namespace TeamB_TD
{
    namespace Unit
    {
        namespace Search
        {
            public class AllySampleSearch2 : ISearcher
            {
                [SerializeField]
                private UnitType _targetType;
                [SerializeField]
                private ColliderTriggerHandler _colliderTriggerHandler;

                private readonly List<ISearchTarget> _targets = new List<ISearchTarget>();

                public UnitType TargetType => _targetType;

                public void Initialize(GameObject gameObject)
                {

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
                    foreach (var old in _targets) old.LostTarget();

                    _targets.Clear();

                    if (_colliderTriggerHandler.Targets.Count != 0)
                    {
                        var target = _colliderTriggerHandler.Targets[0];
                        if (target != null && _targetType.HasFlag(target.UnitType))
                        {
                            _targets.Add(target);
                            target.Target();
                            target.OnDead += OnDeadTarget;
                        }
                    }

                    return _targets;
                }

                private void OnDeadTarget(ISearchTarget target)
                {
                    _targets.Remove(target);
                }
            }
        }
    }
}