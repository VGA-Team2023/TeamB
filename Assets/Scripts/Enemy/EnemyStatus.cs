using System;
using UnityEngine;

//日本語対応
namespace TeamB_TD
{
    namespace Enemy
    {
        [Serializable]
        public struct EnemyStatus
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
            [SerializeField] private float _maxLife;
            [Header("攻撃力")]
            [SerializeField] private float _attackPower;
            [Header("攻撃間隔")]
            [SerializeField] private float _attackInterval;
            [Header("移動速度")]
            [SerializeField] private float _moveSpeed;
            [Header("移動速度にかける倍率")]
            [SerializeField] private float _speedFactor;

            private float _currentLife;

            public EnemyStatus(float life, float power, float interval, float speed, float factor = 1.0f)
            {
                _maxLife = life;
                _currentLife = life;
                _attackPower = power;
                _attackInterval = interval;
                _moveSpeed = speed;
                _speedFactor = factor;
            }

            public void Damage(float damage)
            {
                if (_currentLife <= 0) return;
                _currentLife = MathF.Max(_currentLife - damage, 0f);
            }

            public void Recover(float recover)
            {
                if (_currentLife >= _maxLife) return;
                _currentLife = MathF.Min(_currentLife + recover, _maxLife);
            }

            public void ChangeSpeedFactor(float newSpeedFactor) => _speedFactor = newSpeedFactor;
        }
    }
}