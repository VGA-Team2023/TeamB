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
                StartCoroutine("ResourceCharge");
            }

            IEnumerator ResourceCharge()
            {
                while (true)
                {
                    if(_currentResource.Value < _chargeSpan)
                    {
                        _currentResource.Value++;
                        Debug.Log(_currentResource.Value);
                    }
                    yield return new WaitForSeconds(_chargeSpan);
                }
            }

            /// <summary> Presenter������Ăяo��</summary>
            public void UseResource()
            {
                _currentResource.Value -= 3;
            }
        }
    }
}