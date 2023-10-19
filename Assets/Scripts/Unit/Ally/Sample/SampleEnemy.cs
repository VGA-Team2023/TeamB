// 日本語対応
using UnityEngine;
using TeamB_TD.Unit.Search;
using TeamB_TD.Unit;
using System;
using TeamB_TD;

public class SampleEnemy : MonoBehaviour, ISearchTarget, IDamageable
{
    [SerializeField]
    private UnitType _unitType = UnitType.Enemy;
    [SerializeField]
    private float _life = 10f;

    private int _targetCount = 0;
    private Action<ISearchTarget> _onDead;

    public UnitType UnitType => _unitType;
    public Action<ISearchTarget> OnDead { get => _onDead; set => _onDead = value; }

    public int TargetCount => throw new NotImplementedException();

    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Damage(float value)
    {
        var old = _life;
        _life -= value;
        if (old > 0 && _life <= 0)
        {
            _onDead?.Invoke(this);
            Destroy(this.gameObject); return;
        }
    }

    public IDamageable GetDamageable()
    {
        return this;
    }

    public void Target()
    {
        _targetCount++;
        if (_targetCount > 0)
            _meshRenderer.material.color = Color.red;
    }

    public void LostTarget()
    {
        _targetCount--;
        if (_targetCount <= 0)
        {
            try
            {
                _meshRenderer.material.color = Color.white;
            }
            catch (MissingReferenceException)
            {
                Debug.Log($"Missing...");
                return;
            }
        }
    }
}