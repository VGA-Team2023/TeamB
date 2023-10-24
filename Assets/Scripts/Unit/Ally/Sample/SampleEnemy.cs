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

    public UnitType UnitType => _unitType;
    public event Action<ISearchTarget> OnDead;

    public int TargetCount => _targetCount;

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
            OnDead?.Invoke(this);
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
        {
            try
            {
                _meshRenderer.material.color = Color.red;
            }
            catch (MissingReferenceException)
            {
                Debug.Log($"Missing...");
                return;
            }
        }
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