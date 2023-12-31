// 日本語対応
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TeamB_TD
{
    namespace Unit
    {
        namespace Search
        {
            public class ColliderTriggerHandler : MonoBehaviour
            {
                // ColliderTriggerHandlerを使用する際の注意点。
                // RigidBodyを付ける。
                // ColliderをTriggerにする。
                private List<ISearchTarget> _targets = new List<ISearchTarget>();

                public IReadOnlyList<ISearchTarget> Targets => _targets;

                public event Action<ISearchTarget> OnAddedTarget;
                public event Action<ISearchTarget> OnRemovedTarget;

                public void RemoveTarget(ISearchTarget target)
                {
                    _targets.Remove(target);

                    //Debug.Log($"{target} Removed:\n" +
                    //    $"Current is {string.Join<ISearchTarget>("\n", _targets)}");
                }

                private void OnTriggerEnter(Collider other)
                {
                    if (other.TryGetComponent(out ISearchTarget target))
                    {
                        target.OnDead -= RemoveTarget;
                        _targets.Add(target);
                        target.OnDead += RemoveTarget;
                        OnAddedTarget?.Invoke(target);

                        //Debug.Log($"{target} Removed:\n" +
                        //    $"Current is {string.Join<ISearchTarget>("\n", _targets)}");
                    }
                }

                private void OnTriggerExit(Collider other)
                {
                    if (other.TryGetComponent(out ISearchTarget target))
                    {
                        if (_targets.Remove(target)) OnRemovedTarget?.Invoke(target);

                        target.OnDead -= RemoveTarget;

                        //Debug.Log($"{target} Added:\n" +
                        //    $"Current is {string.Join<ISearchTarget>("\n", _targets)}");
                    }
                }
            }
        }
    }
}