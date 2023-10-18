// 日本語対応
using System.Collections.Generic;
using TeamB_TD.Unit.Search;
using UnityEngine;
using Glib.HitSupport;

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

                public UnitType TargetType => _targetType;

                private readonly List<ISearchTarget> _targets = new List<ISearchTarget>();

                private Transform _origin = null;

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
                    _targets.Clear();

                    var colliders = _overLabBox.GetOverlappingColliders(_origin, out int hitCount);

                    for (int i = 0; i < hitCount; i++)
                    {
                        if (colliders[i].TryGetComponent(out ISearchTarget target))
                        {
                            _targets.Add(target);
                        }
                    }

                    return _targets;
                }
            }
        }
    }
}