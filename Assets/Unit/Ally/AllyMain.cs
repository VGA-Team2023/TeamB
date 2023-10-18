// 日本語対応
using TeamB_TD.Unit.Search;
using UnityEngine;
using Glib.InspectorExtension;
using System;

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

                private Action<ISearchTarget> _onDead;

                public AllyStatus AllyStatus => _allyStatus;
                public ISearcher Searcher => _searcher;
                public UnitType UnitType => _unitType;
                public Action<ISearchTarget> OnDead { get => _onDead; set => _onDead = value; }

                public int TargetCount => throw new NotImplementedException();

                private void Start()
                {
                    _searcher.Initialize(this.gameObject);
                    _allyStatus.Initialize(_searcher);
                }

                private void Update()
                {
                    _allyStatus.Update(Time.deltaTime);
                }

                public void Damage(float value)
                {
                    var oldIsDead = _allyStatus.IsDead;
                    _allyStatus.Damage(value);
                    if (!oldIsDead && _allyStatus.IsDead)
                    {
                        Debug.Log($"{gameObject.name} OnDead");
                        _onDead?.Invoke(this);
                    }
                }

                public IDamageable GetDamageable()
                {
                    return this;
                }

                public void Target()
                {
                    Debug.Log($"{gameObject.name} は標的になった。");
                }

                public void LostTarget()
                {
                    Debug.Log($"{gameObject.name} は標的から外れた。");
                }
            }
        }
    }
}