// 日本語対応
using Glib.InspectorExtension;
using System;
using System.Collections.Generic;
using TeamB_TD.Unit.Search;
using UnityEngine;

namespace TeamB_TD
{
    namespace Unit
    {
        namespace Ally
        {
            public class AllyMain : MonoBehaviour, ISearchTarget, IDamageable
            {
                [SerializeField]
                private UnitType _unitType;
                [SerializeField]
                private AllyStatus _allyStatus;
                [SerializeReference, SubclassSelector]
                private ISearcher _searcher;

                private int _targetCount = 0;
                private List<ISearchTarget> _searchResults;

                public AllyStatus AllyStatus => _allyStatus;
                public ISearcher Searcher => _searcher;
                public UnitType UnitType => _unitType;
                public event Action<ISearchTarget> OnDead;

                public int TargetCount => _targetCount;

                private void Start()
                {
                    _searcher.Initialize(this.gameObject);
                    _searchResults = new List<ISearchTarget>();
                }

                private void Update()
                {
                    AttackUpdate();
                    _allyStatus.Update(Time.deltaTime);
                }

                private void OnDrawGizmos()
                {
                    var gizmoDrawer = _searcher as IDrawableGizmos;
                    if (gizmoDrawer != null)
                    {
                        gizmoDrawer.DrawGizmos(this.gameObject);
                    }
                }

                private void AttackUpdate() // 毎フレーム実行されます。攻撃の処理を担当します。
                {
                    // 結果コレクションと処理コレクションを分離する。
                    _searchResults.Clear();
                    _searchResults.AddRange(_searcher.GetTargets());

                    if (_allyStatus.IsAttackable && _searcher.IsExistTarget)
                    {
                        _allyStatus.Attack(_searchResults);
                    }
                }

                public void Damage(float value)
                {
                    var oldIsDead = _allyStatus.IsDead;
                    _allyStatus.Damage(value);
                    if (!oldIsDead && _allyStatus.IsDead)
                    {
                        Debug.Log($"{gameObject.name} OnDead");
                        OnDead?.Invoke(this);
                    }
                }

                public IDamageable GetDamageable()
                {
                    return this;
                }

                public void Target()
                {
                    _targetCount++;
                    Debug.Log($"{gameObject.name} は標的になった。");
                }

                public void LostTarget()
                {
                    _targetCount--;
                    Debug.Log($"{gameObject.name} は標的から外れた。");
                }
            }
        }
    }
}