// 日本語対応
using Cysharp.Threading.Tasks;
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
            public class AllyMain : UnitBehaviour, ISearchTarget, IDamageable
            {
                [SerializeField]
                private string _name;
                [SerializeField]
                private int _cost;
                [SerializeField]
                private UnitType _unitType;
                [SerializeField]
                private AllyStatus _allyStatus;
                [SerializeReference, SubclassSelector]
                private ISearcher _searcher;

                private LineRenderer _lineRenderer;
                private int _targetCount = 0;
                private List<ISearchTarget> _attackSearchResults;

                public AllyStatus AllyStatus => _allyStatus;
                public ISearcher Searcher => _searcher;
                public UnitType UnitType => _unitType;
                public event Action<ISearchTarget> OnDead;

                public int TargetCount => _targetCount;
                public override string Name => _name;
                public override int Cost => _cost;

                public GameObject GameObject => this ? this.gameObject : null;

                private void Start()
                {
                    _lineRenderer = GetComponent<LineRenderer>();
                    _allyStatus.Initialize();
                    _searcher.Initialize(this.gameObject);
                    _attackSearchResults = new List<ISearchTarget>();
                }

                private void Update()
                {
                    AttackUpdate();
                    AttackLineUpdate();
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

                private async void OnMouseDown()
                {
                    var startPos = Input.mousePosition;
                    // Debug.Log("start");
                    while (!Input.GetMouseButtonUp(0))
                    {
                        if ((startPos - Input.mousePosition).sqrMagnitude > 0.01f)
                        {
                            var mouseDir = DirectionUtility.GetClosestDirection(startPos, Input.mousePosition);
                            this.transform.rotation = DirectionUtility.GetRotationFromDirection(mouseDir);
                        }
                        await UniTask.Yield(cancellationToken: this.GetCancellationTokenOnDestroy());
                    }
                    // Debug.Log("end");
                }

                private void AttackUpdate() // 毎フレーム実行されます。攻撃の処理を担当します。
                {
                    // 結果コレクションと処理コレクションを分離する。
                    _attackSearchResults.Clear();
                    _attackSearchResults.AddRange(_searcher.GetTargets());

                    if (_allyStatus.IsAttackable && _searcher.IsExistTarget)
                    {
                        _allyStatus.Attack(_attackSearchResults);
                    }
                }

                private readonly List<Vector3> _attackLinePositions = new List<Vector3>();

                private void AttackLineUpdate()
                {
                    _attackLinePositions.Clear();
                    _attackLinePositions.Add(transform.position);

                    var targets = _searcher.GetTargets();
                    for (int i = 0; i < targets.Count; i++)
                    {
                        if (targets[i].GameObject)
                            _attackLinePositions.Add(targets[i].GameObject.transform.position);
                    }

                    _lineRenderer.positionCount = _attackLinePositions.Count;
                    _lineRenderer.SetPositions(_attackLinePositions.ToArray());
                }

                public void Damage(float value)
                {
                    var oldIsDead = _allyStatus.IsDead;
                    _allyStatus.Damage(value);
                    if (!oldIsDead && _allyStatus.IsDead)
                    {
                        Debug.Log($"{gameObject.name} OnDead");
                        OnDead?.Invoke(this);
                        Destroy(this.gameObject);
                    }
                }

                public IDamageable GetDamageable()
                {
                    return this;
                }

                public void Target()
                {
                    _targetCount++;
                    // Debug.Log($"{gameObject.name} は標的になった。");
                }

                public void LostTarget()
                {
                    _targetCount--;
                    // Debug.Log($"{gameObject.name} は標的から外れた。");
                }
                private void OnDisable()
                {
                    _searcher.OnDead();
                }
            }
        }
    }
}