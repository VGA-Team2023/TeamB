using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace TeamB_TD
{
    namespace Tower
    {
        public class Tower : MonoBehaviour, IDamageable
        {
            [SerializeField, Tooltip("タワーの最大HP")]
            private float _maxHp = 100f;

            private float _currentHp = 0f;

            /// <summary>
            /// タワーが破壊されたかどうか
            /// </summary>
            private bool _isDestroyed = false;

            public float CurrentHp => _currentHp;
            
            void Start()
            {
                Initialize();
            }
            private void Initialize()
            {
                _isDestroyed = false;
                _currentHp = _maxHp;
            }

            public void Damage(float value)
            {
                _currentHp -= value;

                if (_currentHp <= 0f)
                {
                    DestroyTower();
                }
            }

            private void DestroyTower()
            {
                _isDestroyed = true;
                gameObject.SetActive(false);
            }
        }

    }
}
