using UnityEngine;
using UniRx;
using System;
using System.Collections;

namespace TeamB_TD
{
    namespace ResourceManagement
    {
        public class ResourceModel : MonoBehaviour
        {
            [SerializeField] private int _maxResource;
            [SerializeField] private int _chargeSpan;
            [SerializeField] private IntReactiveProperty _currentResource;

            public IObservable<int> CurrentResourceChanged => _currentResource;

            private void Start()
            {
                //_currentResource.Where(value => value < _maxResource)
                //                .Subscribe(_ =>
                //                {
                //                    StartCoroutine("ResourceCharge");
                //                });
                StartCoroutine("ResourceCharge");
            }

            IEnumerator ResourceCharge()
            {
                while (true)
                {
                    yield return new WaitForSeconds(_chargeSpan);
                    if (_currentResource.Value < _maxResource)
                    {
                        _currentResource.Value++;
                        Debug.Log($"コスト: {_currentResource.Value}");
                    }
                }
            }

            /// <summary> Presenter側から呼び出す</summary>
            public void UseResource()
            {
                _currentResource.Value -= 3;
            }
        }
    }
}

