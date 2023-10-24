using UnityEngine;
using UniRx;
using System.Collections;

namespace TeamB_TD
{
    namespace ResourceManagement
    {
        public class ResourceManager : MonoBehaviour, IResourceManager
        {
            [SerializeField]
            private int _maxResource;
            [SerializeField]
            private int _chargeSpan;
            [SerializeField]
            private IntReactiveProperty _currentResource;

            public IReadOnlyReactiveProperty<int> CurrentResourceChanged => _currentResource;

            public int CurrentResource => _currentResource.Value;

            private void Start()
            {
                StartCoroutine(ResourceCharge());
            }

            IEnumerator ResourceCharge()
            {
                while (true)
                {
                    if (_currentResource.Value < _maxResource)
                    {
                        _currentResource.Value++;
                        Debug.Log(_currentResource.Value);
                    }
                    yield return new WaitForSeconds(_chargeSpan);
                }
            }

            /// <summary> Presenter������Ăяo��</summary>
            public void UseResource(int value)
            {
                _currentResource.Value -= value;
            }
        }
    }
}