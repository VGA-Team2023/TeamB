// 日本語対応
using System.Collections.Generic;
using UnityEngine;

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
                    foreach (var old in _targets)
                    {
                        old.OnDead -= OnDeadTarget;
                        old.LostTarget();
                    }

                    _targets.Clear();
                    var inAreaObjects = _colliderTriggerHandler.Targets;

                    if (inAreaObjects.Count != 0)
                    {
                        ISearchTarget target = null;
                        for (int i = 0; i < inAreaObjects.Count; i++)
                        {
                            if (inAreaObjects[i] != null && _targetType.HasFlag(inAreaObjects[i].UnitType))
                            {
                                target = inAreaObjects[i];
                                break;
                            }
                        }
                        if (target != null)
                        {
                            target.OnDead += OnDeadTarget;
                            target.Target();
                            _targets.Add(target);
                        }
                    }

                    return _targets;
                }

                private void OnDeadTarget(ISearchTarget target)
                {
                    target.OnDead -= OnDeadTarget;
                    target.LostTarget();
                    _targets.Remove(target);
                }
            }
        }
    }
}