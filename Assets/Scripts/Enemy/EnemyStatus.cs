using System;
using UnityEngine;

//日本語対応
namespace TeamB_TD
{
    namespace Enemy
    {
        [Serializable]
        public class EnemyStatus
        {
            /// <summary>最大体力</summary>
            public float MaxLife => _maxLife;
            /// <summary>現在の体力</summary>
            public float CurrentLife => _currentLife;
            /// <summary>攻撃力</summary>
            public float AttackPower => _attackPower;
            /// <summary>攻撃間隔</summary>
            public float AttackInterval => _attackInterval;
            /// <summary>移動速度</summary>
            public float MoveSpeed => _moveSpeed * _speedFactor;
            /// <summary>移動速度にかける倍率</summary>
            public float SpeedFactor { get => _speedFactor; set => _speedFactor = value; }

            [Header("体力")]
            [SerializeReference] private float _maxLife = 1.0f;
            [Header("攻撃力")]
            [SerializeReference] private float _attackPower = 1.0f;
            [Header("攻撃間隔")]
            [SerializeReference] private float _attackInterval = 1.0f;
            [Header("移動速度")]
            [SerializeReference] private float _moveSpeed = 1.0f;
            [Header("移動速度にかける倍率")]
            [SerializeReference] private float _speedFactor = 1.0f;
            [HideInInspector]
            [SerializeReference] private float _currentLife = 1.0f;

            public EnemyStatus()
            {
                _currentLife = _maxLife;
            }

            public void Damage(float damage)
            {
                if (_currentLife <= 0) return;
                _currentLife = MathF.Max(_currentLife - damage, 0f);
            }

            public void Heal(float recover)
            {
                if (_currentLife >= _maxLife) return;
                _currentLife = MathF.Min(_currentLife + recover, _maxLife);
            }

            public void ChangeSpeedFactor(float newSpeedFactor) => _speedFactor = newSpeedFactor;
        }
    }
}